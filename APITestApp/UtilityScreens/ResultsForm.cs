using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APITestApp.Libraries;

namespace APITestApp.UtilityScreens
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
            Initialize();
        }

        #region PRIVATE MEMBERS
        private bool isPassedScript = false;
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Initializes window
        /// </summary>
        private void Initialize()
        {
            isPassedScript = ResultLibrary.allResults.All(x => x.StepExecutionResult == ResultLibrary.StepResult.Passed);
            EditScriptStatus();
            ConstructResultsGrid();
        }

        /// <summary>
        /// Constructs results grid content
        /// </summary>
        private void ConstructResultsGrid()
        {
            foreach (BaseResult result in ResultLibrary.allResults)
            {
                dgvResults.Rows.Add(result.Step.StepNumber, result.Step.StepRequestType, result.Step.StepRequestParameters, result.StepExecutionResult.ToString());
                DataGridViewRow row = dgvResults.Rows[dgvResults.Rows.Count - 1];
                DataGridViewTextBoxCell txtResultCell = row.Cells[3] as DataGridViewTextBoxCell;
                if (txtResultCell.Value.ToString() == "Passed")
                {
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                }
                else if (txtResultCell.Value.ToString() == "Failed")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Changes row color based on whether a step passed or failed
        /// </summary>
        private void EditScriptStatus()
        {
            lblStatus.Text = isPassedScript ? "PASSED" : "FAILED";
            lblStatus.ForeColor = isPassedScript ? Color.DarkGreen : Color.Red;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Handles changing of script name
        /// </summary>
        public void ChangeScriptNameLabel(string ScriptName)
        {
            lblScriptName.Text = ScriptName;
        }
        #endregion

        #region EVENTS
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
