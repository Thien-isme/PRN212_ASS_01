using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository customerRepository;
        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }

        public void AddCustomer(Customer editedCustomer)
        {
            customerRepository.AddCustomer(editedCustomer);
        }

        public void Delete(Customer? selectedCustomer)
        {
            customerRepository.Delete(selectedCustomer);
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerByPhone(string phone)
        {
            return customerRepository.GetCustomerByPhone(phone);
        }

        public List<Customer> SearchByCompanyName(string companyName)
        {
            return customerRepository.SearchByCompanyName(companyName);
        }

        public bool Update(Customer editedCustomer)
        {
            return customerRepository.Update(editedCustomer);
        }

        public bool UploadProfile(Customer customer)
        {
            return customerRepository.UploadProfile(customer);
        }
    }
}
