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
            this.Items = new List<Item>();
        }
        [Key]
        public int ManufacterId { get; set; }
        public string Name { get; set; }
        public string MadeCountry { get; set; }

        // One Manufacter - Many Items 
        public virtual ICollection<Item> Items { get; set; }
    }
}