using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany
{
    public class Company: BusinessObjects.Company, IData
    {
        public static BusinessObjects.Company GetDefaultCompany(int id=0)
        {
            return DataAccessor.GetCompany(id);
        }

        public void SaveData()
        {
            ID = DataAccessor.SaveCompany(CompanyName);
            UpdateDepartments();
        }

        private void UpdateDepartments()
        {
            foreach (var dept in base.Departments)
                dept.CompanyId = ID;
        }
    }

    //public static class Extensions
    //{
    //    public static Company ToLocalComapany(this DataAccessLayer.Company comapany)
    //    {
    //        return new Company { ID = comapany.ID, CompanyName = comapany.CompanyName };
    //    }

    //    public static List<Department> ToLocalDepartment(this IEnumerable<DataAccessLayer.Department> departments)
    //    {
    //        List<Department> deptList = new List<Department>();
    //        foreach (DataAccessLayer.Department dept in departments)
    //            deptList.Add(new Department { CompanyId = dept.CompanyID, DepartmentName = dept.DepartmentName });

    //        return deptList;
    //    }
    //}
}


