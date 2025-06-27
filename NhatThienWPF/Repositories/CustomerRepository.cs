using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private LucySalesDbContext dbContext;

        public CustomerRepository()
        {
            dbContext = new LucySalesDbContext();
        }

        public bool AddCustomer(Customer editedCustomer)
        {
            try
            {
                dbContext.Customers.Add(editedCustomer);
                dbContext.SaveChanges();
                return true; // Thêm thành công
            }
            catch(Exception ex)
            {
                throw ex;
                return false;
            }
            return false;
        }

        public bool Delete(Customer? customer)
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer == null)
            {
                return false; // Customer not found
            }
            existingCustomer.Phone = "";
            dbContext.SaveChanges();
            return true;
        }



        public List<Customer> GetAllCustomers()
        {
            return dbContext.Customers.ToList();
        }

        public Customer GetCustomerByPhone(string phone)
        {
           return dbContext.Customers.FirstOrDefault(c => c.Phone == phone);
        }

        public List<Customer> SearchByCompanyName(string companyName)
        {
            return dbContext.Customers.Where(x => x.CompanyName.Contains(companyName)).ToList();
        }

        public bool Update(Customer customer)
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existingCustomer == null)
            {
                return false; // Customer not found
            }
            existingCustomer.CompanyName = customer.CompanyName;
            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.ContactTitle = customer.ContactTitle;
            existingCustomer.Address = customer.Address;
            existingCustomer.Phone = customer.Phone;
            //dbContext.Customers.Update(customer);
            dbContext.SaveChanges();
            return true;
        }

        public bool UploadProfile(Customer customer)
        {
            var existingCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if(existingCustomer == null)
            {
                return false; // Customer not found
            }
            existingCustomer.CompanyName = customer.CompanyName;
            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.ContactTitle = customer.ContactTitle;
            existingCustomer.Address = customer.Address;
            //dbContext.Customers.Update(customer);
            dbContext.SaveChanges();
            return true;
        }
    }
}
