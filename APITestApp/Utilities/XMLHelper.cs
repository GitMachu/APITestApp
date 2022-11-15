using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APITestApp.Utilities
{
    public class XMLHelper
    {
        public static XDocument LoadXML(string path)
        {
            XDocument xmlDocument = XDocument.Load(path);
            return xmlDocument;
        }

        public static void SaveXML(XDocument documentToSave, string path)
        {
            documentToSave.Save(path);
        }
    }
}
