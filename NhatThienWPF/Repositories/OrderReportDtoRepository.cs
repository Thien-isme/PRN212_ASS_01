using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BussinessObject;
using System.Reflection.Metadata.Ecma335;
namespace Repositories
{
    public class OrderReportDtoRepository
    {
        private LucySalesDbContext dbContext;

        public OrderReportDtoRepository()
        {
            dbContext = new LucySalesDbContext();
        }

        public List<OrderReportDTO> getReportFormTo(DateTime fromDate, DateTime toDate)
        {
            var report = dbContext.Orders
                .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                .Join(dbContext.OrderDetails,
                    o => o.OrderID,
                    od => od.OrderID,
                    (o, od) => new { o, od })
                .Join(dbContext.Customers,
                    combined => combined.o.CustomerID,
                    c => c.CustomerID,
                    (combined, c) => new { combined.o, combined.od, c })
                .Join(dbContext.Employees,
                    combined => combined.o.EmployeeID,
                    e => e.EmployeeID,
                    (combined, e) => new OrderReportDTO
                    {
                        OrderID = combined.o.OrderID,
                        OrderDate = combined.o.OrderDate,
                        CompanyName = combined.c.CompanyName,
                        EmployeeName = e.Name
                    })
                .Distinct()
                .ToList();

            return report;

        }



    }
}
