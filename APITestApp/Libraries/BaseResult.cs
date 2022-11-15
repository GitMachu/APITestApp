using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.Libraries
{
    public class BaseResult
    {
        public ResultLibrary.StepResult StepExecutionResult { get; set; }
        public string StepExecutionDetails { get; set; }
        public string StepError { get; set; }
        public string StepErrorDetails { get; set; }
        public BaseStep Step { get; set; }

        public BaseResult(ResultLibrary.StepResult Result, string ExecutionDetails, string Error = "", string ErrorDetails = "")
        {
            StepExecutionResult = Result;
            StepExecutionDetails = ExecutionDetails;
            StepError = Error;
            StepErrorDetails = ErrorDetails;
        }
        public BaseResult(BaseResult StepResult, BaseStep StepInfo)
        {
            StepExecutionResult = StepResult.StepExecutionResult;
            Step = StepInfo;
        }
    }
}
