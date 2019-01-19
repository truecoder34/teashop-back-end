using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/catalog")]
    public class CatalogController : ApiController
    {

        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        /*
         GET: api/Catalog
         method to get all ITEMS from itemsTable
        */
        [HttpGet]
        [Route("getItems")]
        public IEnumerable<Item> GetItems()
        {
            List<Item> itemsList = new List<Item>();
            itemsList = db.Items.ToList<Item>();
            return itemsList;
        }

        /*
         GET: api/Catalog/5
         method to get  ITEM by ID from itemsTable
        */
        [HttpGet]
        [Route("getItem")]
        public Item GetItem(int id)
        {
            var bufItem = db.Items.Where(b => b.itemId == id).ToList();

            return bufItem[0];
        }

        // POST: api/Catalog
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Catalog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Catalog/5
        public void Delete(int id)
        {
        }
    }
}
