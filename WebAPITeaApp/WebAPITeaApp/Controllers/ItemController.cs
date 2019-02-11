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
    public class ItemController : ApiController
    {

        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        /*
         GET: api/items
         method to get all ITEMS from itemsTable
        */
        [HttpGet]
        [Route("items")]
        public IEnumerable<ItemDto> GetItems()
        {
            List<Item> itemsList = db.Items.ToList<Item>();

            List<ItemDto> itemsDtoList = new List<ItemDto>();
            foreach (Item elem in itemsList)
            {
                ItemDto bufNote = new ItemDto();
                bufNote.GuidIdOfItem = elem.GuidId;
                bufNote.Cost = elem.Cost;
                bufNote.Name = elem.Name;
                bufNote.Description = elem.Description;
                bufNote.ImageLink = elem.ImageLink;
                bufNote.CategoryId = elem.Category.CategoryId;
                bufNote.ManufacterId = elem.Manufacter.ManufacterId;
                itemsDtoList.Add(bufNote);
            }

            //List<ItemDto> itemsDtoList = Mapper.Map<List<Item>, List<ItemDto>>(itemsList);
            return itemsDtoList;
        }

        /*
         GET: api/items/5
         method to get  ITEM by ID from itemsTable
        */
        [HttpGet]
        [Route("items/{id}")]
        public ItemDto GetItem(Guid id)
        {
            var bufItem = db.Items.Where(b => b.GuidId == id).First();

            ItemDto bufNote = new ItemDto();
            bufNote.GuidIdOfItem = bufItem.GuidId;
            bufNote.Cost = bufItem.Cost;
            bufNote.Name = bufItem.Name;
            bufNote.Description = bufItem.Description;
            bufNote.ImageLink = bufItem.ImageLink;
            bufNote.CategoryId = bufItem.Category.CategoryId;
            bufNote.ManufacterId = bufItem.Manufacter.ManufacterId;
            //ItemDto recievedFromDBItem = Mapper.Map<Item, ItemDto>(bufItem);
            return bufNote;
        }

    }
}
