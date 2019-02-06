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
using WebAPITeaApp.Models;

namespace WebAPITeaApp.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    [Authorize(Roles ="Admin")]
    public class ItemAdminController : ApiController
    {
        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        // Add new Item
        [HttpPost]
        [Route("items")]
        public HttpResponseMessage AddItem([FromBody] ItemDto itemDto)
        {
            // Get itemDTO - Map to Item - Add to DB
            Item recievedFromAdminItem = Mapper.Map<ItemDto, Item>(itemDto);

            //ItemDto bufNote = new ItemDto();
            recievedFromAdminItem.GuidId = itemDto.GuidIdOfItem;
            recievedFromAdminItem.Cost = itemDto.Cost;
            recievedFromAdminItem.Name = itemDto.Name;
            recievedFromAdminItem.Description = itemDto.Description;
            recievedFromAdminItem.ImageLink = itemDto.ImageLink;

            recievedFromAdminItem.Category = new Category();
            recievedFromAdminItem.Manufacter = new Manufacter();

            recievedFromAdminItem.Category.CategoryId = itemDto.CategoryId;
            recievedFromAdminItem.Manufacter.ManufacterId = itemDto.ManufacterId;

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
        [Route("items/{id}")]
        public HttpResponseMessage UpdateItem(Guid id, [FromBody] ItemDto itemDto)
        {
            // Get NOTE from tb.ITMENS by ID , type from DB - ITEM 
            var bufItem = db.Items.Where(b => b.GuidId == id).First();

            var bufPhotos = db.Photos.Where(b => b.PhotoId == bufItem.GuidId).ToList();

            // Get itemDTO - transform to DTO
            //Item recievedFromDBAndUpdatedItem = Mapper.Map<ItemDto, Item> (itemDto);

            Item recievedFromDBAndUpdatedItem = new Item();
            //ItemDto bufNote = new ItemDto();
            //recievedFromDBAndUpdatedItem.GuidId = itemDto.GuidIdOfItem;
            recievedFromDBAndUpdatedItem.Cost = itemDto.Cost;
            recievedFromDBAndUpdatedItem.Name = itemDto.Name;
            recievedFromDBAndUpdatedItem.Description = itemDto.Description;
            recievedFromDBAndUpdatedItem.ImageLink = itemDto.ImageLink;

            recievedFromDBAndUpdatedItem.Category = new Category();
            recievedFromDBAndUpdatedItem.Manufacter = new Manufacter();

            recievedFromDBAndUpdatedItem.Category.CategoryId = itemDto.CategoryId;
            recievedFromDBAndUpdatedItem.Manufacter.ManufacterId = itemDto.ManufacterId;

            recievedFromDBAndUpdatedItem.GuidId = bufItem.GuidId;

            try
            {
                db.Items.Remove(bufItem);
                db.Items.Add(recievedFromDBAndUpdatedItem);

                foreach (Photo elem in bufPhotos)
                {
                    Photo photoUpdated = new Photo();
                    photoUpdated.PhotoId = bufItem.GuidId;
                    photoUpdated.LinkPhoto = elem.LinkPhoto;
                    photoUpdated.PhotoId = elem.PhotoId;

                    db.Photos.Remove(bufPhotos[0]);
                    db.Photos.Add(photoUpdated);
                }

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
        [Route("items/{id}")]
        public HttpResponseMessage DeleteItem(Guid id)
        {
            // Get NOTE from tb.ITMENS by ID
            var bufItem = db.Items.Where(b => b.GuidId == id).First();
            var bufPhotos = db.Photos.Where(b => b.PhotoId == bufItem.GuidId).ToList();

            try
            {
                db.Items.Remove(bufItem);
                foreach(Photo elem in bufPhotos)
                {
                    db.Photos.Remove(bufPhotos[0]);
                }
                
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
