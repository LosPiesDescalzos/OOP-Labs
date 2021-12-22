using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Employee
    {
        public Guid Id { get; }

        public string Name { get; }

        public Employee(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}