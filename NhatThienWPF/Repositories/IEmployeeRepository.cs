using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace Repositories
{
    public interface IEmployeeRepository
    {
        public Employee? GetEmployeeByUsernamePassword(string username, string password);
    }
}
