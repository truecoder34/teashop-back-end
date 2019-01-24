using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class OrderDto : EntityDto
    {
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int ManufacterId { get; set; }
        public string ImageLink { get; set; }
    }
}