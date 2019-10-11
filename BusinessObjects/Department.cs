using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Department 
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        private List<Employee> employees = new List<Employee>();
        public List<Employee> Employees
        {
            get { return employees; }
            set
            {
                var _employess = value;
                foreach (var emp in _employess)
                    emp.DepartmentID = ID;

                employees = _employess;
            }
        }
    }
}
