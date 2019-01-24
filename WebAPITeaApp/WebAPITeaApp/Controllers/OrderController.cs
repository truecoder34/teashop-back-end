using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITeaApp.Dto;
using WebAPITeaApp.Models.DB;

namespace WebAPITeaApp.Controllers
{
    [RoutePrefix("api/user")]
    [Authorize]
    public class OrderController : ApiController
    {
        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        // POST: api/Order
        public void Post([FromBody]List<OrderDto> ordersList)
        {
            
        }

    }
}
