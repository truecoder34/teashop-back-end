using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITeaApp.Models.DB
{
    public partial class Item : Entity
    {
        // PK - field, UNIQUE ID of ITEM
        //[Key]
        //public override Guid GuidId { get; set; }

        public float Cost { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string ImageLink { get; set; }

        // FK - field
        //[ForeignKey("CategoryId")]
        //public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // FK - field
        //[ForeignKey("ManufacterId")]
        //public Manufacter 
        public virtual Manufacter Manufacter { get; set; }

        // MANY - to - MANY connection to ORDER table
        // ONE Item - MANY Photo connection to PHOTOS table
        public Item() : base()
        {
            this.Orders = new List<Order>();
            this.Photos = new List<Photo>();
            this.Manufacter = new Manufacter();
            this.Category = new Category();
        }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}