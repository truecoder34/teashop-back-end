using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPITeaApp.Models.DB
{
    public class Manufacter
    {
        public Manufacter()
        {
            this.Items = new HashSet<Item>();
        }
        [Key]
        public int manufacterId { get; set; }
        public string name { get; set; }
        public string madeCountry { get; set; }

        // One Manufacter - Many Items 
        public virtual ICollection<Item> Items { get; set; }
    }
}