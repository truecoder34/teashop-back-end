using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class UserDto : EntityDto
    {
        // NON REQURED Fields to WORK with fields in SYSTEM AspNetUsers Table
        public string UserName { get; set; }
        
        
    }
}