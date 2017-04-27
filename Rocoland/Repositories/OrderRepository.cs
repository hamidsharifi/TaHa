using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Rocoland.Models;

namespace Rocoland.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UpdateOrderStatusById(int orderId , OrderStatus orderStatus)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.OrderStatus = orderStatus;
            }
            
        }

        public void DeleteOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public Order GetMyOrderByUserIdAndOrderStatus(string userid , OrderStatus orderStatus)
        {
            return _context.Orders
                .Where(o => o.CustomerId == userid &&
                            o.OrderStatus == orderStatus)
                .OrderByDescending(o => o.OrderDateTime)
                .Include(o => o.OrderItems)
                .FirstOrDefault();
        }

        public List<Order> GetOrders(OrderStatus orderStatus)
        {
            return _context.Orders
                .Where(o => o.OrderStatus == orderStatus)
                .Include(n => n.Customer)
                .ToList();
        }
    }
}