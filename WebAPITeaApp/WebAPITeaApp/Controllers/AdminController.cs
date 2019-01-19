using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPITeaApp.Models.DB;
using WebAPITeaApp.Dto;
using System.Data.Entity.Migrations;

namespace WebAPITeaApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        // Add new Item
        [HttpPost]
        [Route("addItem")]
        public HttpResponseMessage AddItem([FromBody] ItemDto itemDto)
        {
            Item itemToAdd = new Item();
            itemToAdd.name = itemDto.name;
            itemToAdd.cost = itemDto.cost;
            itemToAdd.description = itemDto.description;
            itemToAdd.categoryId = itemDto.categoryId;
            itemToAdd.manufacterId = itemDto.manufacterId;
            itemToAdd.previewImg = itemDto.imageLink;      
            try
            {
                db.Items.Add(itemToAdd);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Ok");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

        // UPDATE CURRENT ITEM
        // PUT: api/Admin/5
        [HttpPut]
        [Route("updateItem/{id}")]
        public HttpResponseMessage UpdateItem(int id, [FromBody] ItemDto itemDto)
        {
            // Get NOTE from tb.ITMENS by ID
            var bufItem = db.Items.Where(b => b.itemId == id).ToList();
            bufItem[0].cost = itemDto.cost;
            bufItem[0].name = itemDto.name;
            bufItem[0].description = itemDto.description;
            bufItem[0].previewImg = itemDto.imageLink;
            bufItem[0].categoryId = itemDto.categoryId;
            bufItem[0].manufacterId = itemDto.manufacterId;
            try
            {
                db.Items.AddOrUpdate(bufItem[0]);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Ok");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }

        }

        // DELETE CURRENT ITEM
        // DELETE: api/Admin/5
        [HttpDelete]
        [Route("deleteItem/{id}")]
        public HttpResponseMessage DeleteItem(int id)
        {
            // Get NOTE from tb.ITMENS by ID
            var bufItem = db.Items.Where(b => b.itemId == id).ToList();
            
            try
            {
                db.Items.Remove(bufItem[0]);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Ok");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

    }
}
