using LiteDB;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessor
    {
        public static void InitializeLiteDB()
        {
            using (var db = new LiteDatabase("@HelloDb"))
            {
                var company = db.GetCollection<Company>("MyCompany");
                company.Insert(new Company { CompanyName = "Think Ministry" });
            }
        }

        public static Company GetCompany(int companyid = 0)
        {
            using (var db = new LiteDatabase("@HelloDb"))
            {
                if (companyid == 0)
                    return db.GetCollection<Company>("MyCompany").FindAll().FirstOrDefault();
                else
                    return db.GetCollection<Company>("MyCompany").FindOne(c=> c.ID.Equals(companyid));

            }
        }

        public static IEnumerable<Department> GetDepartmentsByCompanyID(int companyid)
        {
            using (var db = new LiteDatabase("@HelloDb"))
            {
              return db.GetCollection<Department>("MyDepartment").Find(c => c.ID.Equals(companyid));
            }
        }

        public static int SaveCompany(string companyname)
        {
            using(var db = new LiteDatabase("@HelloDb"))
            {
                var company = db.GetCollection<Company>("MyCompany").FindOne(c => c.CompanyName.Equals(companyname));
                if (company != null)
                {                    
                    company.CompanyName = companyname;
                    return company.ID;
                }
                else
                {
                    var newcompany = new Company { CompanyName = companyname };
                    return db.GetCollection<Company>("MyCompany").Insert(newcompany);
                }
            }            
        }

        public static int SaveDepartment(string departmentname, int comapnyid)
        {
            using (var db = new LiteDatabase("@HelloDb"))
            {
                var dept = db.GetCollection<Department>("MyDepartment").FindOne(d => d.DepartmentName.Equals(departmentname));
                if (dept != null)
                {
                    dept.DepartmentName = departmentname;
                    dept.CompanyId = comapnyid;
                    return dept.ID;
                }
                else
                {
                    var newdept = new Department { DepartmentName = departmentname, CompanyId = comapnyid };
                    return db.GetCollection<Department>("MyDepartment").Insert(newdept);
                }
            }
        }

        public static int SaveEmployee(string employeename, int yos, int departmentid)
        {
             using(var db = new LiteDatabase("@HelloDb"))
            {
                var employee = db.GetCollection<Employee>("MyEmployee").FindOne(e => e.EmployeeName.Equals(employeename));
                if(employee != null)
                {
                    employee.EmployeeName = employeename;
                    employee.YearsOfSerivce = yos;
                    employee.DepartmentID = departmentid;
                    return employee.ID;
                }
                else
                {
                    var newemployee = new Employee { EmployeeName = employeename, YearsOfSerivce = yos, DepartmentID = departmentid };
                    return db.GetCollection<Employee>("MyEmployee").Insert(newemployee);
                }
            }
        }
    }

    //public class Employee
    //{
    //    [LiteDB.BsonIndex]
    //    public int ID { get; set; }
    //    public int DepartmentID { get; set; }
    //    public string EmployeeName { get; set; }
    //    public int EmployeeYOS { get; set; }
    //}

    //public class Department
    //{
    //    [LiteDB.BsonIndex]
    //    public int ID { get; set; }
    //    public int CompanyID { get; set; }
    //    public string DepartmentName { get; set; }
    //}

    //public class Company
    //{
    //    [LiteDB.BsonIndex]
    //    public int ID { get; set; }
    //    public string CompanyName { get; set; }
    //}
}
