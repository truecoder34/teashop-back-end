using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPITeaApp.Models.DB
{
    public partial class Photo : Entity
    {
        
        public Guid PhotoId { get; set; }
        public string LinkPhoto { get; set; }
        //public string Name_Photo { get; set; }

        // MANY Photo - One Item
        //public Guid GuidId { get; set; }
        //[ForeignKey("GuidId")]
        public virtual Item Item { get; set; }
    }
}