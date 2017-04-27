using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocoland.Models;
using Rocoland.Repositories;
using ActionResult = System.Web.Mvc.ActionResult;
using Controller = System.Web.Mvc.Controller;

namespace Rocoland.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _uow;

        // GET: Product

        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Authorize(Roles = "Administrators")]
        [Authorize]
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orders = _uow.Orders.GetOrders(OrderStatus.Ordered);

            return View(orders);
        }

       

        [Authorize(Roles = "Administrators")]
        public ActionResult Confirm(int id)
        {
            _uow.Orders.UpdateOrderStatusById(id,OrderStatus.Confirmed);
            _uow.SaveChanges();

            var orders = _uow.Orders.
                GetOrders(OrderStatus.Ordered);

            return View("Index",orders);
        }

        [Authorize(Roles = "Customers")]
        public ActionResult Delete(int id)
        {
          _uow.Orders.DeleteOrderById(id);
            _uow.SaveChanges();

            return RedirectToAction("MyOrders");
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Cancel(int id)
        {
            _uow.Orders.UpdateOrderStatusById(id, OrderStatus.Canceled);
            _uow.SaveChanges();

            var orders = _uow.Orders.
                GetOrders(OrderStatus.Ordered);

            return View("Index", orders);
        }

        public ActionResult MyOrders()
        {
            string userid = User.Identity.GetUserId();

            var myLastorder = _uow.Orders.GetMyOrderByUserIdAndOrderStatus(userid, OrderStatus.Ordered);

            return View("MyOrders" , myLastorder.OrderItems);
        }
    }
}