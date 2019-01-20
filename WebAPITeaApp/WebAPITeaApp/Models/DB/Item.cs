using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITeaApp.Models.DB
{
    public partial class Item
    {
        [Key]
        public int ItemId { get; set; }
        public float Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Vategory { get; set; }

        public int ManufacterId { get; set; }
        [ForeignKey("ManufacterId")]
        public virtual Manufacter Manufacter { get; set; }

        // MANY - to - MANY connection to ORDER table
        public Item()
        {
            this.Orders = new HashSet<Order>();
            this.Photos = new HashSet<Photo>();
        }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}