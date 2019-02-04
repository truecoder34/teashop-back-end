using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class StateDto
    {
        public Guid OrderId { get; set; }
        public string State { get; set; }
    }
}