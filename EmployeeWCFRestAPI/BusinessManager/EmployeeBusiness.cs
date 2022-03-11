﻿using BusinessManager.Interface;
using Common.Contracts;
using RepositoryManager;
using RepositoryManager.Interface;
using RepositoryManager.Model;
using System;
using System.Collections.Generic;

namespace BusinessManager
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeBusiness()
        {
            employeeRepository = new EmployeeRepository();
        }
        public IList<EmployeeContract> GetAllEmployee()
        {
            IList<EmployeeContract> employeeContracts = employeeRepository.GetAllEmployee();
            if (employeeContracts != null)
            {
                return employeeContracts;
            }
            else
            {
                return new List<EmployeeContract>();
            }
        }
        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                EmployeeContract empDetails = employeeRepository.AddEmployee(employeeContract);
                if (empDetails.Id > 0)
                {
                    return empDetails;
                }
                else
                {
                    throw new Exception("Employee not able to add.");
                }
            }
            catch(Exception e)
            {
                throw  new Exception(e.Message);
            }
        }

        public string UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            if (employeeRepository.UpdateEmployee(employeeContract, EmpId) == 1)
            {
                return "Employee updated successfully";
            }
            else
            {
                return "Employee not updated";
            }
        }

        public string DeleteEmployee(int empId)
        {
            if(employeeRepository.DeleteEmployee(empId) == 1)
            {
                return "Employee deleted successfuly";
            }
            else
            {
                return "Employee does not exists.";
            }
        }

    }
}
