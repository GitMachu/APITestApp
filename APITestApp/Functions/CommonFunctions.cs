using System;
using APITestApp.Libraries;
using APITestApp.UtilityScreens;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace APITestApp.Functions
{
    /// <summary>
    /// Common methods used by other parts of the application
    /// </summary>
    public class CommonFunctions
    {
        #region ARRAY MEMBERS FOR PARALLEL EXECUTION
        public static bool ManualExecutionStop = false;
        public static bool HasPendingLogText = false;
        public static StatusLogForm StatusForm = new StatusLogForm();
        public static Libraries.BaseResult currentResult;
        #endregion

        #region PRIVATE MEMBERS
        private static string logPath = new FileInfo(CommonFunctions.GetAssemblyPath()).FullName + "\\Logs\\";
        #endregion

        #region PUBLIC MEMBERS
        public enum LogMessageType
        {
            Info,
            Warning,
            Error,
            SuccessMessage
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Flag that signifies whether or not the execution has been interrupted,
        /// which can be triggered by script failure or manual cancellation
        /// </summary>
        public static bool StopExecution()
        {
            if (currentResult == null)
            {
                return ManualExecutionStop;
            }
            return currentResult.StepExecutionResult != ResultLibrary.StepResult.Passed || ManualExecutionStop;
        }

        /// <summary>
        /// Returns executable location
        /// </summary>
        public static string GetAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Main method for logging messages into status log window
        /// </summary>
        public static void LogMessage(string message, bool showTimeStamp = false, bool omitEscape = false, LogMessageType messageType = LogMessageType.Info)
        {
            string cancellationMessageNewLine = "";
            if (HasPendingLogText && message.StartsWith("Cancelling execution"))
            {
                cancellationMessageNewLine = Environment.NewLine;
            }
            HasPendingLogText = omitEscape;
            StatusLogForm.LogMessageType = messageType;
            if (StatusForm != null)
            {
                StatusForm.LogText = cancellationMessageNewLine + (showTimeStamp ? "[" + DateTime.Now.ToString("h:mm:ss tt") + "] " : "") + message + (omitEscape ? "" : Environment.NewLine);
            }
        }

        /// <summary>
        /// Creates result to be interpreted by Results window later
        /// </summary>
        public static void CreateResult(ResultLibrary.StepResult result, string executionDetails, string error = "", string errorDetails = "")
        {
            currentResult = new BaseResult(result, executionDetails, error, errorDetails);
        }

        /// <summary>
        /// Saves result into global result list, then displays messages based on the result
        /// </summary>
        public static void SaveResult(BaseStep step)
        {
            ResultLibrary.allResults.Add(new BaseResult(currentResult, step));
            if (currentResult.StepExecutionResult == ResultLibrary.StepResult.Passed)
            {
                LogMessage("Step " + step.StepNumber + ": " + step.StepRequestType + (step.StepRequestParameters != "" ? " with parameter \"" + step.StepRequestParameters + "\"" : "") + " successfully executed");
                LogMessage("Execution details", false);
                LogMessage("Execution status: ", false, true);
                LogMessage("PASSED", false, false, LogMessageType.SuccessMessage);
                LogMessage("Action message received: " + currentResult.StepExecutionDetails, false);
            }
            else if (currentResult.StepExecutionResult == ResultLibrary.StepResult.Failed)
            {
                LogMessage("Step " + step.StepNumber + ": " + step.StepRequestType + (step.StepRequestParameters != "" ? " with parameter \"" + step.StepRequestParameters + "\"" : "") + " failed to execute");
                LogMessage("Execution details", false);
                LogMessage("Execution status: ", false, true);
                LogMessage("FAILED", false, false, LogMessageType.Error);
                LogMessage("Action message received: " + currentResult.StepExecutionDetails, false);
                LogMessage("Error message received: " + currentResult.StepError, false);
                LogMessage("Error details received: " + currentResult.StepErrorDetails, false);
            }
            if (currentResult.StepExecutionResult == ResultLibrary.StepResult.Skipped)
            {
                LogMessage("Step " + step.StepNumber + ": " + step.StepRequestType + (step.StepRequestParameters != "" ? " with parameter \"" + step.StepRequestParameters + "\"" : "") + " has been skipped");
                LogMessage("Execution details", false);
                LogMessage("Execution status: ", false, true);
                LogMessage("SKIPPED", false, false);
            }
        }

        /// <summary>
        /// Method to save encountered exception into a text file located inside the Logs folder
        /// </summary>
        public static void SaveErrorToFile(string errorMessage, Exception exception, bool showMessageBox = false)
        {
            try
            {
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                logPath = logPath + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".txt";
                if (exception != null)
                {
                    File.AppendAllLines(logPath, new string[]
                    {
                  "[" + DateTime.Now.ToString("h:mm:ss tt") + "] " + "Error encountered in " + exception.Source + Environment.NewLine,
                  "[" + DateTime.Now.ToString("h:mm:ss tt") + "] " + exception.Message + Environment.NewLine,
                  "[" + DateTime.Now.ToString("h:mm:ss tt") + "] " + exception.StackTrace + Environment.NewLine
                    });
                }
                else
                {
                    File.AppendAllLines(logPath, new string[] { "[" + DateTime.Now.ToString("h:mm:ss tt") + "] " + errorMessage + Environment.NewLine });
                }
                if (showMessageBox)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                
            }
        }
        #endregion
    }
}
