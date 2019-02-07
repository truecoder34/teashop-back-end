using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class StateDto : EntityDto
    {
        public Guid OrderId { get; set; }
        public string State { get; set; }
    }
}