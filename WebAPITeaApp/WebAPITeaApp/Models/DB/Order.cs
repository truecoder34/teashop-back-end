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
        public string State { get; set; }
        public DateTime DateTimeProperty { get; set; }
    
        public virtual User User { get; set; }

        // MANY - to - MANY connection to ITEM table
        public Order()
        {
            this.Items = new List<Item>();
            this.User = new User();
        }

        public virtual ICollection<Item> Items { get; set; }
    }
}