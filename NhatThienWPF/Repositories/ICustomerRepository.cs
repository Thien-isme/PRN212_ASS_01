using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerByPhone(string phone);
        public bool UploadProfile(Customer customer);
        public List<Customer> GetAllCustomers();
    }
}
