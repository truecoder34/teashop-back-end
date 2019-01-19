using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class ItemDto
    {
        public string name { get; set; }
        public float cost { get; set; }
        public string description { get; set; }

        public int categoryId { get; set; }
        public int manufacterId { get; set; }
        public string imageLink { get; set; }

        public ItemDto(string nm, float cst, string dsc,
                        int cat_id, int man_id, string img_link)
        {
            name = nm;
            cost = cst;
            description = dsc;
            categoryId = cat_id;
            manufacterId = man_id;
            imageLink = img_link;
        }
    }
}