using AutoMapper;
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
    [RoutePrefix("api")]
    [Authorize]
    public class OrderController : ApiController
    {
        //Connect to DataBase
        TeaShopContext db = new TeaShopContext();

        // POST: api/Order
        [HttpPost]
        [Route("orders")]
        public HttpResponseMessage AddOrder([FromBody]  OrderDto orderDto)
        {
            // Put DATA in ORDERS table
            Guid orderId = Guid.NewGuid();

            Order bufferOrder = new Order();
            bufferOrder.OrderId = orderId;
            bufferOrder.DateTimeProperty = orderDto.DateTimeOfOrder;
            bufferOrder.User = db.Users.Where(b => b.UserId == orderDto.UserGuid).First();

            foreach (var elem in orderDto.ItemsGuidsList)
            { 
                bufferOrder.Items.Add(db.Items.Where(b => b.GuidId == elem).First());        
            }
            db.Orders.Add(bufferOrder);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Ok");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("orders")]
        public List<Order> GetOrders()
        {
            List<Order> order = db.Orders.ToList();
            //List<OrderDto> orderDtoList = new List<OrderDto>();

            //foreach (Order elem in order)
            //{
               
            //}

            return order;
        }


    }
}
