using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        public Customer GetCustomerByPhone(string phone);
        public bool UploadProfile(Customer customer);
        public List<Customer> GetAllCustomers();
    }
}
