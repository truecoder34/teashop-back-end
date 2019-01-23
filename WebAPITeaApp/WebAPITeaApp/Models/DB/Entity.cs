using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Models.DB
{
    public class Entity
    {
        // Guid field
        public Guid Id { get; set; }
        // Constructor 
        public Entity()
        {
            Guid Id = new Guid();
            Id = Guid.NewGuid();
        }
        
    }
}