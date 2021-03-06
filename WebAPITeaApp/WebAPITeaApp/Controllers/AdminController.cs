﻿using System;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        // Add new Item
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("addItem")]
        public HttpResponseMessage AddItem([FromBody] ItemDto itemDto)
        {
            // Get itemDTO - Map to Item - Add to DB
            Item recievedFromDBItem = Mapper.Map<ItemDto, Item>(itemDto);  
            try
            {
                db.Items.Add(recievedFromDBItem);
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
        [Authorize(Roles = "Admin")]
        [Route("updateItem/{id}")]
        public HttpResponseMessage UpdateItem(int id, [FromBody] ItemDto itemDto)
        {
            // Get NOTE from tb.ITMENS by ID , type from DB - ITEM 
            var bufItem = db.Items.Where(b => b.ItemId == id).ToList();

            // Get itemDTO - transform to DTO
            Item recievedFromDBAndUpdatedItem = Mapper.Map<ItemDto, Item> (itemDto);
            try
            {
                db.Items.AddOrUpdate(recievedFromDBAndUpdatedItem);
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
        [Authorize(Roles = "Admin")]
        [Route("deleteItem/{id}")]
        public HttpResponseMessage DeleteItem(int id)
        {
            // Get NOTE from tb.ITMENS by ID
            var bufItem = db.Items.Where(b => b.ItemId == id).ToList();
            
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
