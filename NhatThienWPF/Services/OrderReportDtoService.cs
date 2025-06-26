using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderReportDtoService
    {
        private OrderReportDtoRepository repository;

        public OrderReportDtoService()
        {
            repository = new OrderReportDtoRepository();
        }

        public List<OrderReportDTO> getReportFormTo(DateTime fromDate, DateTime toDate)
        {
            
            return repository.getReportFormTo(fromDate, toDate);
        }
    }
}
