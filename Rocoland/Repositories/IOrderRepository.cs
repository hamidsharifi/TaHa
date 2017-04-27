using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocoland.Models;

namespace Rocoland.Repositories
{
    public interface IOrderRepository
    {
         List<Order> GetOrders(OrderStatus orderStatus);
        void UpdateOrderStatusById(int orderId, OrderStatus orderStatus);
        Order GetMyOrderByUserIdAndOrderStatus(string userid, OrderStatus orderStatus);
        void DeleteOrderById(int id);
        void Create(Order order);

    }
}
