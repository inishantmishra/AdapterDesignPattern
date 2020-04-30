using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace AdapterDesign.BAL
{
    public class JsonGrocery_ObjectAdapter : IXmltoJsonGrocery
    {
        private readonly GroceryManager _groc;
        public JsonGrocery_ObjectAdapter(GroceryManager groc)
        {
            _groc = groc;
        }
        public string getJsonGroceries()
        {
            XmlDocument doc = _groc.GetXMLGroceries();
            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
        }
    }
}