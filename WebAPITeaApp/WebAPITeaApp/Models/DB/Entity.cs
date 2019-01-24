using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Models.DB
{
    public class Entity
    {
        // Guid field
        public Guid GuidId { get; set; }
        // Constructor 
        public Entity()
        {
            //Guid GuidId = new Guid();
            GuidId = Guid.NewGuid();
        }  
    }
}