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
using WebAPITeaApp.Models;
using WebAPITeaApp.Commands;
using WebAPITeaApp.Repository;

namespace WebAPITeaApp.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    [Authorize(Roles ="Admin")]
    public class ItemAdminController : ApiController
    {
        //Connect to DataBase
        static TeaShopContext dbContext = new TeaShopContext();
        // repository object 
        DbRepositorySQL<Item> repository = new DbRepositorySQL<Item>(dbContext);
        Item itemToInsert = new Item();
        ICommandCommonResult result;

        // Add new Item
        [HttpPost]
        [Route("items")]
        public HttpResponseMessage AddItem([FromBody] ItemDto itemDto)
        {
            // Call command create
            try
            {
                CreateItemCommand<ItemDto, Item> CreateItem = new CreateItemCommand<ItemDto, Item>(itemDto, itemToInsert, repository);
                result = CreateItem.Execute();
                return Request.CreateResponse(HttpStatusCode.OK, result);
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
            Item itemToUpdate = new Item();
            try
            {
                UpdateItemCommand<ItemDto, Item> UpdateItem = new UpdateItemCommand<ItemDto, Item>(itemDto, itemToUpdate, repository, id);
                UpdateItem.Execute();
                return Request.CreateResponse(HttpStatusCode.OK, "Note is updated - OK");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }

            //// Get NOTE from tb.ITMENS by ID , type from DB - ITEM 
            //var bufItem = dbContext.Items.Where(b => b.GuidId == id).First();

            //var bufPhotos = dbContext.Photos.Where(b => b.PhotoId == bufItem.GuidId).ToList();

            //// Get itemDTO - transform to DTO
            ////Item recievedFromDBAndUpdatedItem = Mapper.Map<ItemDto, Item> (itemDto);

            //Item recievedFromDBAndUpdatedItem = new Item();
            ////ItemDto bufNote = new ItemDto();
            ////recievedFromDBAndUpdatedItem.GuidId = itemDto.GuidIdOfItem;
            //recievedFromDBAndUpdatedItem.Cost = itemDto.Cost;
            //recievedFromDBAndUpdatedItem.Name = itemDto.Name;
            //recievedFromDBAndUpdatedItem.Description = itemDto.Description;
            //recievedFromDBAndUpdatedItem.ImageLink = itemDto.ImageLink;

            //recievedFromDBAndUpdatedItem.Category = new Category();
            //recievedFromDBAndUpdatedItem.Manufacter = new Manufacter();

            //recievedFromDBAndUpdatedItem.Category.CategoryId = itemDto.CategoryId;
            //recievedFromDBAndUpdatedItem.Manufacter.ManufacterId = itemDto.ManufacterId;

            //recievedFromDBAndUpdatedItem.GuidId = bufItem.GuidId;

            //try
            //{
            //    dbContext.Items.Remove(bufItem);
            //    dbContext.Items.Add(recievedFromDBAndUpdatedItem);

            //    foreach (Photo elem in bufPhotos)
            //    {
            //        Photo photoUpdated = new Photo();
            //        photoUpdated.PhotoId = bufItem.GuidId;
            //        photoUpdated.LinkPhoto = elem.LinkPhoto;
            //        photoUpdated.PhotoId = elem.PhotoId;

            //        dbContext.Photos.Remove(bufPhotos[0]);
            //        dbContext.Photos.Add(photoUpdated);
            //    }

            //    dbContext.SaveChanges();
            //    return Request.CreateResponse(HttpStatusCode.OK, "Ok");
            //}
            //catch
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            //}

        }

        // DELETE CURRENT ITEM
        // DELETE: api/Admin/5
        [HttpDelete]
        [Route("items/{id}")]
        public HttpResponseMessage DeleteItem(Guid id)
        {
            // Get NOTE from tb.ITMENS by ID
            var bufItem = dbContext.Items.Where(b => b.GuidId == id).First();
            var bufPhotos = dbContext.Photos.Where(b => b.PhotoId == bufItem.GuidId).ToList();

            try
            {
                dbContext.Items.Remove(bufItem);
                foreach(Photo elem in bufPhotos)
                {
                    dbContext.Photos.Remove(bufPhotos[0]);
                }

                dbContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Ok");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");
            }
        }

    }
}
