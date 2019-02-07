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
        [Authorize(Roles = "User")]
        public HttpResponseMessage AddOrder([FromBody]  OrderDto orderDto)
        {
            // Get INFO about user from USERINFO table by userGuid, and put it into User Table
            try
            {
                UserInfo userInfo = db.UsersInfo.Where(b => b.UserId == orderDto.UserGuid).First();
                User userMakingOrder = new User();
                userMakingOrder.UserId = userInfo.UserId;
                userMakingOrder.Name = userInfo.Name;
                userMakingOrder.Surname = userInfo.Surname;
                userMakingOrder.Email = userInfo.Email;
                userMakingOrder.AccessMod = 0;

                db.Users.Add(userMakingOrder);
                db.SaveChanges();
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No personal information about user");
            }
            


            // Put DATA in ORDERS table
            Guid orderId = Guid.NewGuid();
            Order bufferOrder = new Order();
            bufferOrder.OrderId = orderId;
            bufferOrder.DateTimeProperty = orderDto.DateTimeOfOrder;
            bufferOrder.User = db.Users.Where(b => b.UserId == orderDto.UserGuid).First();
            bufferOrder.State = "Создан";

            foreach (var elem in orderDto.ItemsGuidsList)
            { 
                bufferOrder.Items.Add(db.Items.Where(b => b.GuidId == elem).First());        
            }
            db.Orders.Add(bufferOrder);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Ok");
        }

        [HttpGet]
        [Route("orders/{id}")]
        [Authorize(Roles = "User")]
        public List<OrderDto> GetUsersOrders(Guid id)
        {
            List<Order> order = db.Orders.Where(b => b.User.UserId == id).ToList();
            List<OrderDto> orderDtoList = new List<OrderDto>();
            foreach (Order elem in order)
            {
                OrderDto orderDto = new OrderDto();
                orderDto.DateTimeOfOrder = elem.DateTimeProperty;
                orderDto.UserGuid = elem.User.UserId;
                orderDto.State = elem.State;
                orderDto.ItemsGuidsList = new List<Guid>();
                foreach (Item item in elem.Items)
                {
                    orderDto.ItemsGuidsList.Add(item.GuidId);
                }
                orderDtoList.Add(orderDto);
            }
            return orderDtoList;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("orders")]
        public List<OrderDto> GetOrders()
        {
            List<Order> order = db.Orders.ToList();           
            List<OrderDto> orderDtoList = new List<OrderDto>();
            foreach (Order elem in order)
            {
                OrderDto orderDto = new OrderDto();
                orderDto.DateTimeOfOrder = elem.DateTimeProperty;
                orderDto.UserGuid = elem.User.UserId;
                orderDto.State = elem.State;
                orderDto.ItemsGuidsList = new List<Guid>();
                foreach (Item item in elem.Items)
                {
                    orderDto.ItemsGuidsList.Add(item.GuidId);
                }
                orderDtoList.Add(orderDto);
            }
            return orderDtoList;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("orders/update")]
        public HttpResponseMessage updateState([FromBody] StateDto stateDto)
        {
            Order orderFromDb = db.Orders.Where(b => b.OrderId == stateDto.OrderId).First();

            orderFromDb.State = stateDto.State;

            List<Order> bufferList = db.Orders.ToList();

            //db.Orders.Add(orderFromDb);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "State Updated");
        }

    }
}
