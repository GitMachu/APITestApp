using System;
using System.Drawing;
using System.Windows.Forms;
using APITestApp.Functions;

namespace APITestApp.UtilityScreens
{
    /// <summary>
    /// Form that displays current execution status using log messages
    /// </summary>
    public partial class StatusLogForm : Form
    {

        public StatusLogForm()
        {
            InitializeComponent();
            this.Activate();
        }

        #region PUBLIC MEMBERS
        public int threadIndex;
        public static CommonFunctions.LogMessageType LogMessageType = CommonFunctions.LogMessageType.Info;
        #endregion

        #region PROPERTIES
        public string LogText
        {
            get
            {
                return txtLogs.Text;
            }
            set
            {
                txtLogs.Invoke(() => { txtLogs.AppendText(value, SetLogTextColor()); });
            }
        }

        public string StatusText
        {
            get
            {
                return lblStatus.Text;
            }
            set
            {
                lblStatus.Text = value;
            }
        }
        #endregion


        #region PUBLIC METHODS
        /// <summary>
        /// Changes close and cancel button states based on if an execution is finished
        /// </summary>
        public void ChangeStatusFormButtonStates(bool isExecutionFinished)
        {
            btnClose.Enabled = isExecutionFinished;
            btnCancelExecution.Enabled = !isExecutionFinished;
        }

        /// <summary>
        /// Changes content of script name label
        /// </summary>
        public void ChangeScriptNameLabel(string ScriptName)
        {
            lblScriptName.Text = ScriptName;
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Changes color of text to appear in logs based on log message type
        /// </summary>
        private Color SetLogTextColor()
        {
            Color textColor = Color.Black;
            if (LogMessageType == CommonFunctions.LogMessageType.Error)
            {
                textColor = Color.Red;
            }
            else if (LogMessageType == CommonFunctions.LogMessageType.SuccessMessage)
            {
                textColor = Color.DarkGreen;
            }
            else if (LogMessageType == CommonFunctions.LogMessageType.Warning)
            {
                textColor = Color.Orange;
            }
            return textColor;
        }
        #endregion

        #region EVENTS
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelExecution_Click(object sender, EventArgs e)
        {
            CommonFunctions.ManualExecutionStop = true;
            CommonFunctions.LogMessage("Cancelling execution...", true, false, CommonFunctions.LogMessageType.Error);
            btnCancelExecution.Enabled = false;
        }

        private void btn_EnabledChanged(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = button.Enabled == false ? Color.LightGray : Color.FromArgb(0, 85, 255);
        }
        #endregion


    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    public static class ControlExtensions
    {
        public static void Invoke(this System.Windows.Forms.Control control, System.Action action)
        {
            if (control.InvokeRequired) control.Invoke(new MethodInvoker(action), null);
            else action.Invoke();
        }
    }
}
