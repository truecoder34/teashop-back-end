using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Items = new List<Item>();
        }
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // One Category - Many Items
        public virtual ICollection<Item> Items { get; set; }
    }
}