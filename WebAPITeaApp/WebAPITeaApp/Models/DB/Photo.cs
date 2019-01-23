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
        public Guid PhotoId { get; set; }
        public string LinkPhoto { get; set; }
        //public string Name_Photo { get; set; }

        // MANY Photo - One Item
        public Nullable<int> IdOfNoteInTable { get; set; }
        [ForeignKey("IdOfNoteInTable")]
        public virtual Item Item { get; set; }
    }
}