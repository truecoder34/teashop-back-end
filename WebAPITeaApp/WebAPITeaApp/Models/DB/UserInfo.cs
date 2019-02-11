using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Models.DB
{
    public class UserInfo : Entity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}