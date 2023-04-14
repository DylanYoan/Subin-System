using SubIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Subin.Controllers
{
    public class ApiItemsController : ApiController
    {
        // GET api/<controller>
        public List<Item> Get()
        {
            return new Item().GetItem();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] Item itemcito)
        {
            try
            {
                itemcito.AddItem(itemcito);
                
            }
            catch (Exception e)
            {
                string msg = e.Message;
                
            }

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}