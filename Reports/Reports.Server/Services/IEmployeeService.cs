using System;
using System.Collections.Generic;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        void SerializeEmployee(List<Employee> employees);
        List<Employee> DeSerializeEmployee();
        Employee Create(string name);

        Employee FindByName(string name);

        Employee FindById(Guid id);

        void Delete(Guid id);
        void AddEmployeeToSupervisor(Guid idSupervisor, Guid idEmployee);
    }
}