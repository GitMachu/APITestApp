using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.Libraries
{
    public class ResultLibrary
    {
        public enum StepResult
        {
            Passed,
            Failed,
            Skipped
        }
        public static List<BaseResult> allResults = new List<BaseResult>();
    }
}
