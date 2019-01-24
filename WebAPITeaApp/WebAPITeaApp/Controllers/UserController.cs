using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models;

namespace WebAPITeaApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/user")]
    [Authorize]
    public class UserController : ApiController
    {

        ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [Route("getRole")]
        public string GetItem([FromBody] UserDto user)
        {
            string userName = user.UserName;
            var userFromDb = db.Users.Where(b => b.UserName == userName).ToList();
            var listOfRoles = userFromDb[0].Roles.ToList();

            var rolesFromDb = db.Roles.ToList();
            string userRoleId = rolesFromDb[1].Id;
            string adminRoleId = rolesFromDb[0].Id;

            if(listOfRoles[0].RoleId == adminRoleId)
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
           
        }
    }
}
