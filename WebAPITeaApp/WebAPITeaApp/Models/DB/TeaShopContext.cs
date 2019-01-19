using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebAPITeaApp.Models;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Models.DB
{
    public class TeaShopContext : DbContext
    {

        //public TeaShopContext()
        //    : base("name=TeaShopDBEntities")
        //{
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacter> Manufacters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}