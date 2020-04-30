using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using AdapterDesign.Models;

namespace AdapterDesign.BAL
{
    public class GroceryManager
    {
        public XmlDocument GetXMLGroceries()
        {
            List<Grocery> groceries = new List<Grocery>();
            groceries.Add(new Grocery {grocId = "KJA1", price = "136.00 USD", qty = "5", weight = "141.9 gm"});
            groceries.Add(new Grocery { grocId = "TAD1", price = "243.35 USD", qty = "7", weight = "545.7 gm" });
            groceries.Add(new Grocery { grocId = "ASD23", price = "45.00 USD", qty = "12", weight = "14.5 gm" });
            groceries.Add(new Grocery { grocId = "PASJ2", price = "150.20 USD", qty = "8", weight = "800.0 gm" });
           
            XElement xel= new XElement("Groceries",
                           from groc in groceries
                           select new XElement("Grocery",
                                        new XAttribute("ID", groc.grocId),
                                          new XElement("Price", groc.price),
                                          new XElement("Qty", groc.qty),
                                          new XElement("Weight", groc.weight)
                                      ));

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xel.ToString());
            return xDoc;
        }
    }
}