using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public void AddOrder(Order newOrder)
        {
            orderRepository.AddOrder(newOrder);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderRepository.AddOrderDetail(orderDetail);
        }

        public int CreateOrderID()
        {
            return orderRepository.CreateOrderID();
        }

        public List<Order> GetAllOrdered()
        {
            return orderRepository.GetAllOrdered();
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return orderRepository.GetOrdersByCustomerId(customerId);
        }
    }
}
