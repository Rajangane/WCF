using Common.Contracts;
using RepositoryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Interface
{
    public interface IEmployeeBusiness
    {
        IList<EmployeeContract> GetAllEmployee();

        EmployeeContract AddEmployee(EmployeeContract employeeContract);

        string UpdateEmployee(EmployeeContract employeeContract, int EmpId);

        string DeleteEmployee(int empId);

    
    }
}



