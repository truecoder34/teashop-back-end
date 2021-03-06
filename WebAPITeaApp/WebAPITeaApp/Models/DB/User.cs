﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;

namespace WebAPITeaApp.Models.DB
{
    public partial class User : Entity
    {
        //[Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int AccessMod { get; set; }
        //public string Address { get; set; }

        // One USER - Many Orders
        public User()
        {
            this.Orders = new List<Order>();
        }
        public virtual ICollection<Order> Orders { get; set; }
    }
}