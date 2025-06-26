using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Password { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}