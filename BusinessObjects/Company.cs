using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        private List<Department> departments = new List<Department>();
        public List<Department> Departments
        {
            get { return departments; }
            set
            {
                var _departments = value;
                foreach (var dept in _departments)
                    dept.CompanyId = ID;

                departments = _departments;
            }
        }
        public override string ToString()
        {
            return CompanyName;
        }
    }
}


