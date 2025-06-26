using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LucySalesDbContext dbContext;

        public EmployeeRepository()
        {
            dbContext = new LucySalesDbContext();
        }

        public Employee? GetEmployeeByUsernamePassword(string username, string password)
        {
            return dbContext.Employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
        }
    }
}
