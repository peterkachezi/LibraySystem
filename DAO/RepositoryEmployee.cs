using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RepositoryEmployee
    {

        public static bool AddEmployee(EmployeeBLL employeeBLL)
        {
            t_Employees employee = new t_Employees();

            employee.Id = Guid.NewGuid();

            employee.FirstName = employeeBLL.FirstName;

            employee.LastName = employeeBLL.LastName;

            employee.MobileNumber = employeeBLL.MobileNumber;

            employee.CreateDate = DateTime.Now;

            using (StudentsEntities context = new StudentsEntities())
            {
                context.t_Employees.Add(employee);

                return context.SaveChanges() > 0;
            }

        }
        public static List<EmployeeBLL> GetAllEmployees()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Employees = context.t_Employees.OrderByDescending(x => x.CreateDate).ToList();

                var employees = new List<EmployeeBLL>();

                foreach (var t_Employee in t_Employees )
                {
                    var employe = new EmployeeBLL();

                    employe.Id = t_Employee.Id;

                    employe.FirstName = t_Employee.FirstName;

                    employe.LastName = t_Employee.LastName;

                    employe.MobileNumber = t_Employee.MobileNumber;

                    employees.Add(employe);
                }

                return employees;
            }
        }
    }
}
