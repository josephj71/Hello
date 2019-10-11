using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Department: BusinessObjects.Department, IData
    {
        public static IEnumerable<BusinessObjects.Department> GetDepartmentsByCompanyID(int compid)
        {
            return DataAccessor.GetDepartmentsByCompanyID(compid);
        }

        public void SaveData()
        {
           ID = DataAccessor.SaveDepartment(DepartmentName, CompanyId);
           UpdateEmployess();
        }

        private void UpdateEmployess()
        {
            foreach (var emp in base.Employees)
                emp.DepartmentID = ID;
        }

        public override string ToString()
        {
            return DepartmentName;
        }
    }
}
