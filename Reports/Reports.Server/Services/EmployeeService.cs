using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Reports.Server.Controllers;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private string jsonPath = "employees.json";
        private Repository<Employee> repository = new Repository<Employee>();

        public void SerializeEmployee(List<Employee> employees)
        {
            repository.Serialize(employees, jsonPath);
        }
        
        public List<Employee> DeSerializeEmployee()
        {
           return repository.DeSerialize(jsonPath);
        }
        
        
        public Employee Create(string name)
        {
            Employee employee = new Employee(Guid.NewGuid(), name);
            List<Employee> employees = DeSerializeEmployee();
            if (employees == null)
            {
                employees = new List<Employee>();
            }
            employees.Add(employee);
            SerializeEmployee(employees);
            return employee;
        }

        public Employee FindByName(string name)
        {
            List<Employee> employees = DeSerializeEmployee();
            Employee findEmployee = null;
            foreach (var employee in employees)
            {
                if (employee.Name == name)
                {
                    findEmployee = employee;
                }
            }
            SerializeEmployee(employees);
            return findEmployee;
        }

        public Employee FindById(Guid id)
        {
            List<Employee> employees = DeSerializeEmployee();
            Employee findEmployee = null;
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    findEmployee = employee;
                }
            }
            SerializeEmployee(employees);
            return findEmployee;
        }

        public void Delete(Guid id)
        {
            List<Employee> employees = DeSerializeEmployee();
            
            foreach (var employee in employees.ToList())
            {
                if (employee.Id == id)
                {
                    employees.Remove(employee);
                }
            }
            SerializeEmployee(employees);
        }

        public void AddEmployeeToSupervisor(Guid idSupervisor, Guid idEmployee)
        { 
            List<Employee> employees = DeSerializeEmployee();
            if (employees == null)
            {
                employees = new List<Employee>();
            }
            foreach (var supervisor in employees)
            {
                if (supervisor.Id == idSupervisor)
                {
                    foreach (var employee in employees)
                    {
                        if (employee.Id == idEmployee)
                        {
                            supervisor.Employees.Add(employee);
                        }
                    }
                }
            }
            SerializeEmployee(employees);
        }
    }
}