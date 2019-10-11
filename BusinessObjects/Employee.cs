using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Employee 
    {
        public  int ID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeName { get; set; }
        public int YearsOfSerivce { get; set; }
    }
}
