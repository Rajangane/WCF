using Common.Contracts;
using RepositoryManager.Interface;
using RepositoryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryManager
{
    public class EmployeeRepository : IEmployeeRepository
    {
        employee_managementEntities3 employeeManagementEntitiesObj;
        public EmployeeRepository()
        {
            employeeManagementEntitiesObj = new employee_managementEntities3();
        }

        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            EmployeeDetail employee = new EmployeeDetail()
            {
                Name = employeeContract.Name,
                Email = employeeContract.Email,
                Salary = employeeContract.Salary
            };
            employeeManagementEntitiesObj.EmployeeDetails.Add(employee);
            employeeManagementEntitiesObj.SaveChanges();
            employeeContract.Id = employee.Id;
            return employeeContract;


        }

        public int DeleteEmployee(int empId)
        {
            var employee = (from a in employeeManagementEntitiesObj.EmployeeDetails 
                            where a.Id == empId select a).FirstOrDefault();
            if(employee!=null)
            {
                employeeManagementEntitiesObj.EmployeeDetails.Remove(employee);
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public IList<EmployeeContract> GetAllEmployee()
        {
            var query = (from a in employeeManagementEntitiesObj.EmployeeDetails select a).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();

            query.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Salary = x.Salary
                });
            });

            return employeeData;
        }

       

        public int UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            EmployeeDetail employee = employeeManagementEntitiesObj
                .EmployeeDetails.Find(EmpId);
            if(employee != null)
            {
                employee.Email = employeeContract.Email;
                employee.Name = employeeContract.Name;
                employee.Salary = employeeContract.Salary;
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                throw new Exception("Employee do not exists");
            }
        }

    }
}
