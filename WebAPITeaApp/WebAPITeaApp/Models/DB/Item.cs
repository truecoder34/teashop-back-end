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
        public int itemId { get; set; }
        public float cost { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string previewImg { get; set; }

        public Nullable<int> categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category category { get; set; }

        public int manufacterId { get; set; }
        [ForeignKey("manufacterId")]
        public virtual Manufacter manufacter { get; set; }

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