using MyCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            //var comp = Company.GetDefaultCompany(2);
            //var depts = Department.GetDepartmentsByCompanyID(comp.ID);
            //if (!string.IsNullOrEmpty(comp.CompanyName))
            //{
            //    Console.WriteLine(comp);
            //    foreach (var dept in depts)
            //    {
            //        Console.WriteLine(dept.DepartmentName);
            //        foreach (var emp in dept.Employees)
            //            Console.WriteLine(emp.EmployeeName);
            //    }
            //}
            //else
            //{
                var employee = new Employee();

                employee.EmployeeName = Utility.GetAnswer("What is your name?");

                var company = new Company();
                var department = new Department();

                company.CompanyName = Utility.GetAnswer($"Who do you work for {employee}?");

                int yos = 0;
                int.TryParse(Utility.GetAnswer($"How long have you worked at {company}"), out yos);

                employee.YearsOfSerivce = yos;

                department.DepartmentName = Utility.GetAnswer("What department are you in?");

                company.Departments.Add(department);
                department.Employees.Add(employee);

                List<IData> myobjects = new List<IData>();
                myobjects.Add(company);
                myobjects.Add(department);
                myobjects.Add(employee);

                SaveData(myobjects);

                Console.WriteLine($"Hello {employee}, I see you work for {company}, in the {department} department, for {employee.YearsOfSerivce} years!");
            //}

            Console.ReadLine();
        }

        private static void SaveData(List<IData> myobjects)
        {
            foreach(var obj in myobjects)
            {
                obj.SaveData();
            }
        }
    }

    public static class Utility
    {
        public static string GetAnswer(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
