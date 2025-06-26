using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private LucySalesDbContext dbContext;

        public OrderRepository()
        {
            dbContext = new LucySalesDbContext();
        }

        public void AddOrder(Order newOrder)
        {
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            dbContext.OrderDetails.Add(orderDetail);
            dbContext.SaveChanges();
        }

        public int CreateOrderID()
        {
            int max = dbContext.Orders.Max(o => o.OrderID);
            return max + 1;
        }

        public List<Order> GetAllOrdered()
        {
            return dbContext.Orders.ToList();
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return dbContext.Orders
                .Where(o => o.CustomerID == customerId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }
    }
}
