using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPITeaApp.Models.DB
{
    public partial class Photo
    {
        [Key]
        public int photoId { get; set; }
        public string linkPhoto { get; set; }
        //public string Name_Photo { get; set; }

        // MANY Photo - One Item
        public Nullable<int> itemId { get; set; }
        [ForeignKey("itemId")]
        public virtual Item item { get; set; }
    }
}