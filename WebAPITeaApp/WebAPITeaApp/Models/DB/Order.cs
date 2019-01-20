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
        [Key]
        public int OrderId { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //public int Item_Id { get; set; }
        //[ForeignKey("Item_Id")]
        //public virtual Item item { get; set; }


        // MANY - to - MANY connection to ITEM table
        public Order()
        {
            this.Items = new HashSet<Item>();
        }
        public virtual ICollection<Item> Items { get; set; }
    }
}