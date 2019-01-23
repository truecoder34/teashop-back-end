using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPITeaApp.Models.DB;
using WebAPITeaApp.Dto;
using AutoMapper;

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
        public IEnumerable<ItemDto> GetItems()
        {
            List<Item> itemsList = db.Items.ToList<Item>();
            List<ItemDto> itemsDtoList = Mapper.Map<List<Item>, List<ItemDto>>(itemsList);
            return itemsDtoList;
        }

        /*
         GET: api/Catalog/5
         method to get  ITEM by ID from itemsTable
        */
        [HttpGet]
        [Route("getItem/{id}")]
        public ItemDto GetItem(Guid id)
        {
            var bufItem = db.Items.Where(b => b.Id == id).ToList();
            ItemDto recievedFromDBItem = Mapper.Map<Item, ItemDto>(bufItem[0]);
            return recievedFromDBItem;
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
