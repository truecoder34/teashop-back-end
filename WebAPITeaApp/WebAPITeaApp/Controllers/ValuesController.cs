using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITeaApp.Models;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

        TeaShopContext db = new TeaShopContext();
        // GET api/values
        public IEnumerable<Category> Get()
        {
            return db.Categories;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
