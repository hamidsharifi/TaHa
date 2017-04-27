using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rocoland.Controllers;
using Rocoland.Models;
using Rocoland.Repositories;
using System.Web.Mvc;
using FluentAssertions;
using Rocoland.Test.Extensions;

namespace Rocoland.Test
{
    [TestClass]
    public class OrderControllerTests
    {
        private readonly OrderApiController _orderController;
        public OrderControllerTests()
        {
            var uow = new Mock<IUnitOfWork>();
            var mockOrder = new Mock<IOrderRepository>();

            uow.SetupGet(u => u.Orders).Returns(mockOrder.Object);

            _orderController = new OrderApiController(uow.Object);

            _orderController.MockCurrentUser("talaa.rajabi@gmail.com","1");
        }

        [TestMethod]
        public void GetOrderNotifications_noorder_notfound()
        {
            var result = _orderController.GetOrderNotifications();

            result.Should().BeOfType<NotFoundResult>();

        }
    }
}
