using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class UserInfoDto
    {
        // NON REQUIRD FIELDS to WORK with fields in table UsersInfo OR Users
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string UserId { get; set; }

    }
}