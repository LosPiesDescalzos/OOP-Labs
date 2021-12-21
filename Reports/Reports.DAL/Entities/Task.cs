using System;
using System.Collections.Generic;
using Reports.Server.Services;

namespace Reports.DAL.Entities
{
    public class Task
    {
        public Guid Id { get; }
        public string Name { get; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        
        public List<string> Comments { get; set; } = new List<string>();
        public Employee Employee { get; set; }
        public DateTime Create { get; }
        public DateTime LastChange { get; set; }
        public Task(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Status = TaskStatus.Open;
            Create = DateTime.Now;
            LastChange = default;
            Description = description;
        }

        public void UpDate(DateTime date)
        {
            LastChange = date;
            Status = TaskStatus.Active;
        }
     
        
    }
}