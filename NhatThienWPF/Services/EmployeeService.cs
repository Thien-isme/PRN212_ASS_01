using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository employeeRepository = new EmployeeRepository();


        public Employee GetEmployeeByUsernamePassword(string username, string password)
        {
            return employeeRepository.GetEmployeeByUsernamePassword(username, password);
        }
    }
}
