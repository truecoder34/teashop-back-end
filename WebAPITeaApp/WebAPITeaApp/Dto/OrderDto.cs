using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITeaApp.Dto
{
    public class OrderDto : EntityDto
    {
        public Guid UserGuid { get; set; }
        public DateTime DateTimeOfOrder { get; set; }

        public ICollection<Guid> ItemsGuidsList { get; set; }

        public string State { get; set; }

    }
}