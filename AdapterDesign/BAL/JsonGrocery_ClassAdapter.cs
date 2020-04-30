using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace AdapterDesign.BAL
{
    public class JsonGrocery_ClassAdapter : GroceryManager, IXmltoJsonGrocery
    {
        public string getJsonGroceries()
        {
            XmlDocument doc = GetXMLGroceries();
            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
        }
    }
}