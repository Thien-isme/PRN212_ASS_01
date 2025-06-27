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

        public bool Delete(int orderID)
        {
            try
            {
                var orderDetails = dbContext.OrderDetails.Where(o => o.OrderID == orderID).ToList();
                if (orderDetails.Any())
                {
                    dbContext.OrderDetails.RemoveRange(orderDetails);
                    var order = dbContext.Orders.FirstOrDefault(x => x.OrderID == orderID);
                    dbContext.Orders.Remove(order);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Ghi nhật ký lỗi hoặc ném lại ngoại lệ để xử lý ở tầng cao hơn
                Console.WriteLine($"Lỗi khi xóa chi tiết đơn hàng cho OrderID {orderID}: {ex.Message}");
                throw new Exception($"Không thể xóa chi tiết đơn hàng cho OrderID {orderID}.", ex);
            }

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
