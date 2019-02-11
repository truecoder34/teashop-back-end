using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Models.DB
{
    abstract public class Entity
    {
        // Guid field - field to make note in table UN
        [Key]
        public Guid GuidId{ get; set; }
        // Constructor 
        public Entity()
        {
            GuidId = Guid.NewGuid();
        }  
    }
}