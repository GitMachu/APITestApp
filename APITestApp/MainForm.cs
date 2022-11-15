using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;
using APITestApp.Functions;
using APITestApp.Libraries;
using APITestApp.Utilities;

namespace APITestApp
{
    /// <summary>
    /// Main window of application
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }
        #region PRIVATE MEMBERS

        private DataTable dtSteps = new DataTable();
        private string scriptPath = "";
        private DataTable stepTable = new DataTable();
        private bool isClicked = false;
        private bool appendParametersToURL = false;
        private Stopwatch executionWatch = new Stopwatch();
        private UtilityScreens.StatusLogForm statusLogForm = new UtilityScreens.StatusLogForm();
        private BackgroundWorker executionWorker = new BackgroundWorker();
        private string currentScriptName = "";
        private RestResponse currentResponse;

        #endregion

        #region CONSTANTS
        private const string URL = "https://jsonplaceholder.typicode.com";
        private const string defaultItemString = "--SELECT--";
        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Runs initial code needed by the tool
        /// </summary>
        private void Initialize()
        {
            InitializeStepGrid();
            InitializeRequestTypes();
            scriptPath = new FileInfo(CommonFunctions.GetAssemblyPath()).FullName + "\\Scripts\\";
            PopulateScriptList(scriptPath);
        }

        /// <summary>
        /// Creates datagridview in code for better customization
        /// </summary>
        private void InitializeStepGrid()
        {
            DataGridViewComboBoxColumn cmbRequestType = new DataGridViewComboBoxColumn();
            cmbRequestType.HeaderText = "Action";
            cmbRequestType.Name = "cmbRequestType";
            dgvSteps.Columns.Add(cmbRequestType);
            DataGridViewTextBoxColumn txtParameters = new DataGridViewTextBoxColumn();
            txtParameters.HeaderText = "Parameters";
            txtParameters.Name = "txtParameters";
            txtParameters.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSteps.Columns.Add(txtParameters);
            dtSteps.Clear();
            dgvSteps.DataSource = dtSteps;
        }

        /// <summary>
        /// Adds all possible request types to the dropdown
        /// </summary>
        private void InitializeRequestTypes()
        {
            DataGridViewComboBoxColumn cmb = dgvSteps.Columns[0] as DataGridViewComboBoxColumn;
            cmb.Items.Clear();
            cmb.Items.Add(defaultItemString);
            foreach (string name in RequestLibrary.GetAllRequestTypes())
            {
                if (!cmb.Items.Contains(name))
                {
                    cmb.Items.Add(name);
                }
            }
            int maxWidth = 0;
            foreach (var obj in cmb.Items)
            {
                int temporaryWidth = TextRenderer.MeasureText(obj.ToString(), cmb.DefaultCellStyle.Font).Width;
                if (temporaryWidth > maxWidth)
                {
                    maxWidth = temporaryWidth;
                }
            }
            cmb.DropDownWidth = maxWidth;
            cmb.Width = maxWidth;
        }

        /// <summary>
        /// Determines what method to use based on chosen action type
        /// </summary>
        private void InterpretAction(int stepCount, string actionType, string actionParameters)
        {
            try
            {
                switch(actionType)
                {
                    case string action when action.Contains("request"):
                        SendRequest(actionType, actionParameters);
                        break;
                    case string assertion when assertion.Contains("Assertion"):
                        PerformAssertion(actionType, actionParameters);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.CreateResult(ResultLibrary.StepResult.Failed, actionType + " failed", ex.Message, "");
            }
            finally
            {
                CommonFunctions.SaveResult(new BaseStep(stepCount, actionType, actionParameters));
            }
        }

        /// <summary>
        /// Sends request to endpoint based on request type
        /// </summary>
        private void SendRequest(string actionType, string actionParameters)
        {
            string subURL = "users";
            bool hasParameters = actionParameters != "";
            Dictionary<string, string> convertedParameters = new Dictionary<string, string>();
            if (hasParameters)
            {
                convertedParameters = RequestLibrary.ConvertParameters(actionParameters);
                if (appendParametersToURL)
                {
                    subURL = subURL + "?" + BuildParameterURLString(convertedParameters);
                    CommonFunctions.LogMessage("Append parameters to URL enabled", true);
                    CommonFunctions.LogMessage("New resource URL: " + subURL, true);
                }
            }
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest(subURL, actionType.Contains("GET") ? Method.Get : Method.Post);
            if (hasParameters && !appendParametersToURL)
            {
                foreach (KeyValuePair<string, string> parameterPair in convertedParameters)
                {
                    request.AddParameter(parameterPair.Key, parameterPair.Value);
                }
            }
            request.RequestFormat = RestSharp.DataFormat.Json;
            currentResponse = client.Execute(request);
            CommonFunctions.LogMessage("Status code: " + currentResponse.StatusCode.ToString(), true);
            CommonFunctions.LogMessage(actionType + " result: " + (currentResponse.IsSuccessful ? "PASSED" : "FAILED"), true);
            CommonFunctions.CreateResult(currentResponse.IsSuccessful ? ResultLibrary.StepResult.Passed : ResultLibrary.StepResult.Failed, currentResponse.Content != null ? currentResponse.Content : currentResponse.ErrorMessage);
        }

        /// <summary>
        /// Creates a partial endpoint string to be used in direct endpoint requests
        /// </summary>
        private string BuildParameterURLString(Dictionary<string, string> parameterPairs)
        {
            string subURL = "";
            foreach (KeyValuePair<string, string> parameterPair in parameterPairs)
            {
                subURL += parameterPair.Key + "=" + (parameterPair.Value.Contains(" ") ? "'" + parameterPair.Value + "'"
                          : parameterPair.Value) + "&";
            }
            subURL = subURL.TrimEnd('&');
            return subURL;
        }

        /// <summary>
        /// Compares result set to values set in assertion
        /// </summary>
        private void PerformAssertion(string actionType, string actionParameters)
        {
            Dictionary<string, string> convertedParameters = RequestLibrary.ConvertParameters(actionParameters);
            JArray fullResponse = new JArray();
            JObject responseObject = new JObject();
            JToken token = JToken.Parse(currentResponse.Content);
            if (token.Type == JTokenType.Array)
            {
                fullResponse = JArray.Parse(currentResponse.Content);
            }
            if (fullResponse.Any())
            {
                responseObject = JObject.Parse(JArray.Parse(currentResponse.Content).First().ToString());
            }
            else
            {
                responseObject = JObject.Parse(currentResponse.Content);
            }

            bool isAssertionSuccessful = false;
            object expectedValue = new object();
            object actualValue = new object();
            switch (actionType)
            {
                case string _statusCode when actionType.Contains("statuscode"):
                    string responseCodeString = (int)currentResponse.StatusCode + " " + currentResponse.StatusCode;
                    expectedValue = actionParameters;
                    actualValue = responseCodeString;
                    break;
                case string _recordCount when actionType.Contains("count"):
                    int expectedCount = Convert.ToInt32(actionParameters.Split('=').Last());
                    int valuesCount = convertedParameters.Any() ? responseObject[convertedParameters.First().Key].ToList().Count()
                                                              : fullResponse.Count;
                    expectedValue = expectedCount;
                    actualValue = valuesCount;
                    break;
                case string _specificRecord when actionType.Contains("specificrecord"):
                    Dictionary<string, object> recordValues = responseObject.ToObject<Dictionary<string, object>>();
                    string actualRecord = recordValues.Where(x => x.Key == convertedParameters.First().Key).First().Value.ToString();
                    expectedValue = convertedParameters.First().Value;
                    actualValue = actualRecord;
                    break;
            }
            if (expectedValue == null && actualValue == null)
            {
                CommonFunctions.LogMessage("Both comparison values are empty", true);
                CommonFunctions.CreateResult(ResultLibrary.StepResult.Failed, "Both comparison values are empty", "Empty assertion values error");
                return;
            }
            string assertionErrorMessage = "";
            string assertionString = "Expected value: " + expectedValue.ToString() + ", Actual value: " + actualValue.ToString();
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                isAssertionSuccessful = true;
            }
            catch (Exception e)
            {
                assertionErrorMessage = e.Message;
            }
            CommonFunctions.LogMessage("Assertion finished: " + actionType);
            CommonFunctions.LogMessage(assertionString);
            CommonFunctions.LogMessage(isAssertionSuccessful ? "" : assertionErrorMessage);
            CommonFunctions.CreateResult(isAssertionSuccessful ? ResultLibrary.StepResult.Passed : ResultLibrary.StepResult.Failed, assertionString, !isAssertionSuccessful ? assertionErrorMessage : "");
        }

        /// <summary>
        /// Populates treeview with scripts
        /// </summary>
        private void PopulateScriptList(string path)
        {
            tvwScripts.Nodes.Clear();
            var rootDirectory = new DirectoryInfo(path);
            foreach (var directory in rootDirectory.GetDirectories())
            {
                var stack = new Stack<TreeNode>();
                var node = new TreeNode(directory.Name) { Tag = directory };
                stack.Push(node);

                while (stack.Count > 0)
                {
                    var currentNode = stack.Pop();
                    var directoryInfo = (DirectoryInfo)currentNode.Tag;
                    foreach (var dir in directoryInfo.GetDirectories())
                    {
                        var childDirectoryNode = new TreeNode(dir.Name) { Tag = dir };
                        currentNode.Nodes.Add(childDirectoryNode);
                        stack.Push(childDirectoryNode);
                    }
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        if (file.Extension.ToLower() == ".xml")
                        {
                            currentNode.Nodes.Add(new TreeNode(file.Name));
                        }
                    }
                }
                tvwScripts.Nodes.Add(node);
            }
            foreach (var file in rootDirectory.GetFiles())
                if (file.Extension.ToLower() == ".xml")
                {
                    tvwScripts.Nodes.Add(new TreeNode(file.Name));
                }
        }

        /// <summary>
        /// Clears all step grid rows
        /// </summary>
        private void ClearStepGrid()
        {
            DataTable stepTable = (DataTable)dgvSteps.DataSource;
            if (stepTable != null)
            {
                stepTable.Clear();
            }
        }

        /// <summary>
        /// Checks validity of all data in grid - all must be valid steps in order to be used for execution
        /// </summary>
        private bool IsAnyStepInvalid()
        {
            foreach (DataGridViewRow row in dgvSteps.Rows)
            {
                if (row.Cells[0].Value.ToString() == defaultItemString)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Initializes main thread code, including script execution
        /// </summary>
        private void ExecuteSteps()
        {
            executionWorker = new BackgroundWorker();
            int stepCount = 0;
            int totalStepCount = dgvSteps.Rows.Count;
            statusLogForm.StatusText = "Step " + stepCount + "/" + totalStepCount;
            executionWorker.WorkerReportsProgress = true;
            executionWorker.WorkerSupportsCancellation = true;

            executionWorker.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;
                foreach (DataRow row in stepTable.Rows)
                {
                    string actionType = row[0].ToString();
                    string actionParameters = row[1].ToString();
                    stepCount++;
                    BaseStep step = new BaseStep(stepCount, actionType, actionParameters);
                    CommonFunctions.LogMessage("Executing script step " + stepCount + ":", true);
                    CommonFunctions.LogMessage("Action type is " + actionType + ":", true);
                    CommonFunctions.LogMessage("Action has " + (actionParameters == "" ? "no parameters" : "parameters \"" + actionParameters + "\""));
                    try
                    {
                        if (CommonFunctions.StopExecution() && !ResultLibrary.allResults.Any(x => x.Step.StepNumber == stepCount))
                        {
                            CommonFunctions.CreateResult(ResultLibrary.StepResult.Skipped, "Action skipped because of " + (CommonFunctions.ManualExecutionStop ? " manual cancellation" : " a previous step's failure"));
                            CommonFunctions.SaveResult(step);
                            continue;
                        }
                        InterpretAction(stepCount, actionType, actionParameters);
                        if (CommonFunctions.StopExecution() && !ResultLibrary.allResults.Any(x => x.Step.StepNumber == stepCount))
                        {
                            CommonFunctions.CreateResult(ResultLibrary.StepResult.Skipped, "Action skipped because of " + (CommonFunctions.ManualExecutionStop ? " manual cancellation" : " a previous step's failure"));
                            CommonFunctions.SaveResult(step);
                        }
                    }
                    catch (Exception e)
                    {
                        if (ResultLibrary.allResults.Any(x => x.Step.StepNumber == stepCount))
                        {
                            BaseResult result = ResultLibrary.allResults.FirstOrDefault(x => x.Step.StepNumber == stepCount);
                            result.StepExecutionResult = ResultLibrary.StepResult.Failed;
                            result.StepError = e.Message;
                            result.StepErrorDetails = "";
                        }
                    }
                    b.ReportProgress(stepCount / totalStepCount * 100);
                }
                
                if (ResultLibrary.allResults.Count < stepTable.Rows.Count)
                {
                    try
                    {
                        for (int count = ResultLibrary.allResults.Count - 1; count < stepTable.Rows.Count; count++)
                        {
                            DataRow row = stepTable.Rows[count];
                            string requestType = row[0].ToString();
                            string requestParameters = row[1].ToString();
                            BaseStep step = new BaseStep(stepCount, requestType, requestParameters);
                            CommonFunctions.CreateResult(ResultLibrary.StepResult.Skipped, "Action skipped because of " + (CommonFunctions.ManualExecutionStop ? " manual cancellation" : " a previous step's failure"));
                            CommonFunctions.SaveResult(step);
                        }
                    }
                    catch (Exception e)
                    {
                        CommonFunctions.LogMessage("An error has been encountered while compiling skipped rows. Error message follows", true);
                        CommonFunctions.LogMessage(e.Message);
                    }
                }
                executionWatch.Stop();
                if (CommonFunctions.ManualExecutionStop)
                {
                    CommonFunctions.LogMessage("Execution manually cancelled", true, false, CommonFunctions.LogMessageType.Warning);
                }
                int totalStepsExecuted = ResultLibrary.allResults.FindAll(x => x.Step.StepNumber != 0 && x.StepExecutionResult == ResultLibrary.StepResult.Passed).Count();
                CommonFunctions.LogMessage("Execution " + (CommonFunctions.StopExecution() ? "interrupted " : "completed ") + ": " + totalStepsExecuted + "/" + totalStepCount + " steps executed", true);
                CommonFunctions.LogMessage("Script execution stopped after " + executionWatch.Elapsed.ToString(@"m\:ss\.fff"));
                b.ReportProgress(100);
            });

            executionWorker.ProgressChanged += new ProgressChangedEventHandler(
            delegate (object o, ProgressChangedEventArgs args)
            {
                statusLogForm.StatusText = "Step " + stepCount + "/" + totalStepCount;
            });

            executionWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object o, RunWorkerCompletedEventArgs args)
            {
                if (args.Error != null)
                {
                    CommonFunctions.SaveErrorToFile(args.Error.StackTrace, args.Error);
                    CommonFunctions.LogMessage("An unhandled exception has been encountered in the execution thread. Please send the following message to your administrator for diagnosis.", true, false, CommonFunctions.LogMessageType.Error);
                    CommonFunctions.LogMessage(args.Error.Message, false, false, CommonFunctions.LogMessageType.Error);
                }
                statusLogForm.ChangeStatusFormButtonStates(true);
                UtilityScreens.ResultsForm resultsForm = new UtilityScreens.ResultsForm();
                resultsForm.ChangeScriptNameLabel(currentScriptName);
                resultsForm.Show();
                CommonFunctions.ManualExecutionStop = false;
                CommonFunctions.HasPendingLogText = false;
                executionWorker.Dispose();
            });
            executionWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Starts request execution
        /// </summary>
        private void StartRequestRun()
        {
            if (dgvSteps.Rows.Count == 0)
            {
                MessageBox.Show("The step grid is empty. Please add at least 1 step for it to be a valid script.", "Step grid empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (IsAnyStepInvalid())
            {
                MessageBox.Show("One of the steps has an invalid value. Please remove all instances of \"--SELECT--\" in all step dropdowns.", "Invalid step value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            appendParametersToURL = chkAppendToURL.Checked;
            stepTable = new DataTable();
            foreach (DataGridViewColumn col in dgvSteps.Columns)
            {
                stepTable.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvSteps.Rows)
            {
                DataRow dataRow = stepTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                stepTable.Rows.Add(dataRow);
            }
            ResultLibrary.allResults.Clear();
            CommonFunctions.currentResult = null;
            currentScriptName = txtScriptName.Text;
            statusLogForm = new UtilityScreens.StatusLogForm();
            statusLogForm.ChangeScriptNameLabel(currentScriptName);
            statusLogForm.ChangeStatusFormButtonStates(false);
            CommonFunctions.StatusForm = statusLogForm;
            statusLogForm.Show();
            executionWatch.Restart();
            ExecuteSteps();
        }
        #endregion

        #region EVENTS
        private void btnRun_Click(object sender, EventArgs e)
        {
            StartRequestRun();
        }

        private void dgvSteps_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1 && isClicked);
            var datagridview = sender as DataGridView;
            bool isCellReadOnly = dgvSteps.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly;
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick && !isCellReadOnly)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
            isClicked = false;
        }


        private void dgvSteps_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSteps.IsCurrentCellDirty)
            {
                dgvSteps.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtSteps.NewRow();
            dtSteps.Rows.Add(newRow);
            DataGridViewComboBoxCell cmbRequestCell = dgvSteps.Rows[dgvSteps.Rows.Count - 1].Cells[0] as DataGridViewComboBoxCell;
            DataGridViewTextBoxCell txtParamCell = dgvSteps.Rows[dgvSteps.Rows.Count - 1].Cells[1] as DataGridViewTextBoxCell;
            cmbRequestCell.Value = cmbRequestCell.Items[0];
        }

        private void dgvSteps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isClicked = true;
        }

        private void dgvSteps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            isClicked = true;
        }

        private void dgvSteps_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSteps.Rows.Count == 0)
            {
                MessageBox.Show("The step grid is empty. Please add at least 1 step for it to be a valid script.", "Step grid empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (IsAnyStepInvalid())
            {
                MessageBox.Show("One of the steps has an invalid value. Please remove all instances of \"--SELECT--\" in all step dropdowns.", "Invalid step value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string file = Directory.GetFiles(scriptPath, txtScriptName.Text + ".xml", SearchOption.AllDirectories).FirstOrDefault();
            if (file != null)
            {
                DialogResult saveMessageResult = MessageBox.Show("File already exists. Overwrite?", "Overwrite existing file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (saveMessageResult == DialogResult.No)
                {
                    return;
                }
            }
            file = scriptPath + txtScriptName.Text + ".xml";
            List<XElement> steps = new List<XElement>();
            int stepNumber = 1;
            foreach (DataGridViewRow row in dgvSteps.Rows)
            {
                steps.Add(new XElement("step",
                    new XAttribute("stepnumber", stepNumber),
                    new XElement("requesttype", row.Cells[0].Value.ToString()),
                    new XElement("parameters", row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "")
                    )
                    );
                stepNumber++;
            }

            XElement scriptRecord = new XElement("script",
                    new XAttribute("scriptname", txtScriptName.Text),
                    steps
                    );
            XDocument xmlDocument = new XDocument(scriptRecord);
            XMLHelper.SaveXML(xmlDocument, file);
            PopulateScriptList(scriptPath);
            MessageBox.Show("Save successful", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tvwScripts.SelectedNode != null)
            {
                DialogResult deleteDialogResult = MessageBox.Show($"Are you sure you want to delete {tvwScripts.SelectedNode.FullPath} ?", "Delete File", MessageBoxButtons.YesNo);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    string pathToDelete = scriptPath + tvwScripts.SelectedNode.FullPath;
                    File.Delete(pathToDelete);
                    MessageBox.Show("Delete successful.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateScriptList(scriptPath);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (tvwScripts.SelectedNode != null)
            {
                ClearStepGrid();
                XDocument stepXML = XMLHelper.LoadXML(scriptPath + tvwScripts.SelectedNode.FullPath);
                var dataScript = from doc in stepXML.Descendants("script")
                                 select new
                                 {
                                     scriptname = doc.Attribute("scriptname").Value
                                 };
                txtScriptName.Text = dataScript.First().scriptname;
                var dataSteps = from doc in stepXML.Descendants("step")
                                select new
                                {
                                    stepnumber = doc.Attribute("stepnumber").Value,
                                    requesttype = doc.Element("requesttype").Value,
                                    parameters = doc.Element("parameters").Value
                                };

                foreach (var stepValue in dataSteps)
                {
                    int stepIndex = Convert.ToInt32(stepValue.stepnumber);
                    DataRow newRow = dtSteps.NewRow();
                    dtSteps.Rows.Add(newRow);
                    DataGridViewComboBoxCell cmbRequestCell = dgvSteps.Rows[dgvSteps.Rows.Count - 1].Cells[0] as DataGridViewComboBoxCell;
                    DataGridViewTextBoxCell txtParamCell = dgvSteps.Rows[dgvSteps.Rows.Count - 1].Cells[1] as DataGridViewTextBoxCell;
                    cmbRequestCell.Value = cmbRequestCell.Items[cmbRequestCell.Items.IndexOf(stepValue.requesttype) < 0 ? 0 : cmbRequestCell.Items.IndexOf(stepValue.requesttype)];
                    txtParamCell.Value = stepValue.parameters;
                }
                dgvSteps.Refresh();
            }
            tvwScripts.SelectedNode = null;
            MessageBox.Show("Script load successful", "Load Script", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtScriptName.Clear();
            ClearStepGrid();
        }

        private void btnDeleteStep_Click(object sender, EventArgs e)
        {
            if (dgvSteps.SelectedCells.Count > 0)
            {
                dgvSteps.Rows.RemoveAt(dgvSteps.CurrentCell.RowIndex);
            }
        }

        private void btn_EnabledChanged(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = button.Enabled == false ? Color.LightGray : Color.FromArgb(0, 85, 255);
        }
        #endregion
    }
}
