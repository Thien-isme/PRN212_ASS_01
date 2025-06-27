using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailsViewModelRepository
    {
        private readonly LucySalesDbContext dbContext;
        public OrderDetailsViewModelRepository()
        {
            dbContext = new LucySalesDbContext();
        }

        public IQueryable<Order> GetOrderWithDetails(int orderId)
        {
            // Thực hiện Include ở tầng Repository
            return dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.OrderID == orderId); // Lọc sớm để tối ưu truy vấn
        }



    }
}
