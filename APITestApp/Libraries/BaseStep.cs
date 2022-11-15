using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp.Libraries
{
    public class BaseStep
    {
        public int StepNumber { get; set; }
        public string StepRequestType { get; set; }
        public string StepRequestParameters { get; set; }

        public BaseStep(int StepCount, string RequestType, string RequestParameters)
        {
            StepNumber = StepCount;
            StepRequestType = RequestType;
            StepRequestParameters = RequestParameters;
        }
    }
}
