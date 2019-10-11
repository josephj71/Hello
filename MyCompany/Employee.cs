using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Employee: BusinessObjects.Employee,  IData
    {
        public void SaveData()
        {
            ID = DataAccessor.SaveEmployee(EmployeeName, YearsOfSerivce, DepartmentID);
        }

        public override string ToString()
        {
            return EmployeeName;
        }
    }
}
