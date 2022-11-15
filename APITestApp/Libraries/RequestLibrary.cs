using System.Collections.Generic;
using System.Linq;

namespace APITestApp.Libraries
{
    /// <summary>
    /// Methods related to requests to send
    /// </summary>
    public class RequestLibrary
    {
        /// <summary>
        /// Returns list of all request types
        /// </summary>
        public static List<string> GetAllRequestTypes()
        {
            List<string> allRequests = new List<string>();
            allRequests.Add("GET request");
            allRequests.Add("POST request");
            allRequests.Add("Assertion - statuscode");
            allRequests.Add("Assertion - count");
            allRequests.Add("Assertion - specificrecord");
            allRequests.Sort();
            return allRequests;
        }

        /// <summary>
        /// Returns parameter-value pairs
        /// </summary>
        public static Dictionary<string, string> ConvertParameters(string parameterString)
        {
            Dictionary<string, string> convertedParameters = new Dictionary<string, string>();
            List<string> parameterStrings = parameterString.Split('&').ToList();
            foreach (string paramString in parameterStrings)
            {
                if (paramString.Contains("="))
                {
                    convertedParameters.Add(paramString.Split('=').First(), paramString.Split('=').Last());
                }
            }
            return convertedParameters;
        }
    }
}
