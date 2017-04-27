using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Microsoft.ApplicationInsights.Web;
using Microsoft.ApplicationInsights.WindowsServer;
using Microsoft.AspNet.Identity;
using Rocoland.Models;
using Rocoland.Repositories;

namespace Rocoland.Controllers
{
    [Authorize]
    public class OrderApiController : ApiController
    {
        private readonly IUnitOfWork _uow;

        public OrderApiController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(Order))]
        public IHttpActionResult Post(int id)
        {
            var userid = User.Identity.GetUserId();

            Order orderer = new Order
            {
                OrderDateTime = DateTime.Now,
                CustomerId = userid,
             //   ProductId = id,
                OrderStatus = OrderStatus.Ordered
            };

            _uow.Orders.Create(orderer);
            _uow.SaveChanges();

            return Ok(orderer);
            
        }

        [HttpGet]
        public IHttpActionResult GetOrderNotifications()
        {
            var notifications = _uow.Orders.GetOrders(OrderStatus.Ordered);
            if(notifications == null) 
                return NotFound();

            return Ok(notifications);
        }
    }
}
