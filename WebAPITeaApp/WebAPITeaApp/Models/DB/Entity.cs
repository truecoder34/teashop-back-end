using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Models.DB
{
    public class Entity
    {
        // Guid field
        public Guid GuidIdOfItem { get; set; }
        // Constructor 
        public Entity()
        {
            //Guid GuidId = new Guid();
            GuidIdOfItem = Guid.NewGuid();
        }  
    }
}