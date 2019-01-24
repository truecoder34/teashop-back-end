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
using AutoMapper;

namespace WebAPITeaApp.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : ApiController
    {
        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        // Add new Item
        [HttpPost]
        [Route("addItem")]
        public HttpResponseMessage AddItem([FromBody] ItemDto itemDto)
        {
            // Get itemDTO - Map to Item - Add to DB
            Item recievedFromAdminItem = Mapper.Map<ItemDto, Item>(itemDto);

            // temporarily decision = replace giud to prevent it being zero 
            Guid tempGuid = Guid.NewGuid();
            recievedFromAdminItem.GuidId = tempGuid;
            try
            {
                db.Items.Add(recievedFromAdminItem);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, tempGuid);
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
        public HttpResponseMessage UpdateItem(Guid id, [FromBody] ItemDto itemDto)
        {
            // Get NOTE from tb.ITMENS by ID , type from DB - ITEM 
            var bufItem = db.Items.Where(b => b.GuidId == id).First();

            // Get itemDTO - transform to DTO
            Item recievedFromDBAndUpdatedItem = Mapper.Map<ItemDto, Item> (itemDto);
            recievedFromDBAndUpdatedItem.GuidId = bufItem.GuidId;
            try
            {
                db.Items.Remove(bufItem);
                db.Items.Add(recievedFromDBAndUpdatedItem);
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
        public HttpResponseMessage DeleteItem(Guid id)
        {
            // Get NOTE from tb.ITMENS by ID
            var bufItem = db.Items.Where(b => b.GuidId == id).ToList();
            
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
