using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Dto
{
    public class ItemDto : Entity
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int ManufacterId { get; set; }
        public string ImageLink { get; set; }


        //public ItemDto(string name, float cost, string description,
        //                int cat_id, int man_id, string img_link)
        //{
        //    Name = name;
        //    Cost = cost;
        //    Description = description;
        //    CategoryId = cat_id;
        //    ManufacterId = man_id;
        //    ImageLink = img_link;
        //}
    }
}