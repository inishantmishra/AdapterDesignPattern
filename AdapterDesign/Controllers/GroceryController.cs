using AdapterDesign.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AdapterDesign.Controllers
{
    public class GroceryController : ApiController
    {
        // GET: api/Grocery
        //Without Adapter Design Pattern
        [HttpGet]
        [Route("api/grocery/groceries")]
        public HttpResponseMessage GetGroceries()
        {
            GroceryManager grocManager = new GroceryManager();
            
            return new HttpResponseMessage()
            { Content = new StringContent(grocManager.GetXMLGroceries().InnerXml, 
              Encoding.UTF8, 
              "application/xml")
            };
        }

        // GET: api/Grocery/5
        //Class Adapter Design Pattern
        [HttpGet]
        [Route("api/grocery/ClassAdapter")]
        public HttpResponseMessage GetClassAdapter()
        {
            
            return new HttpResponseMessage()
            {
                Content = new StringContent(
                              new JsonGrocery_ClassAdapter().getJsonGroceries(),
              Encoding.UTF8,
              "application/json")
            };
        }

        // GET: api/Grocery/5
        //Object Adapter Design Pattern
        [HttpGet]
        [Route("api/grocery/ObjectAdapter")]
        public HttpResponseMessage GetObjectAdapter()
        {
            GroceryManager groc = new GroceryManager();
            return new HttpResponseMessage()
            {
                Content = new StringContent(
                              new JsonGrocery_ObjectAdapter(groc).getJsonGroceries(),
              Encoding.UTF8,
              "application/json")
            };
        }

        // POST: api/Grocery
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Grocery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Grocery/5
        public void Delete(int id)
        {
        }
    }
}
