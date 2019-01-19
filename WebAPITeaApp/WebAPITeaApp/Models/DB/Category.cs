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
            this.Items = new HashSet<Item>();
        }
        [Key]
        public int categoryId { get; set; }
        public string name { get; set; }

        // One Category - Many Items
        public virtual ICollection<Item> Items { get; set; }
    }
}