using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITeaApp.Models.DB
{
    public partial class Order 
    {
        // PK - field, UNIQUE ID of ORDER
        [Key]
        public Guid OrderId { get; set; }

        public DateTime DateTimeProperty { get; set; }

        //[ForeignKey("User")]
        //public Guid UserRefId { get; set; }
        public virtual User User { get; set; }

        // Relation to unique Item ID from Items table
        //[ForeignKey("Item")]
        //public int GuidRefId { get; set; }
        //public virtual Item Item { get; set; }


        // MANY - to - MANY connection to ITEM table
        public Order()
        {
            this.Items = new List<Item>();
        }

        public virtual ICollection<Item> Items { get; set; }
    }
}