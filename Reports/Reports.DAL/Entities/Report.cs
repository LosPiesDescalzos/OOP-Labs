using System;
using System.Collections.Generic;

namespace Reports.DAL.Entities
{
    public class Report
    {
        public Guid Id { get; }

        public DateTime Create { get; }
        public ReportStatus Status { get; set; }
        public string Description { get; }
        public List<Task> Tasks { get; set;} = new List<Task>();

        public Employee Employee { get; set; } 

        public Report(Guid id, string description)
        {
            Id = id;
            Status = ReportStatus.Open;
            Create = DateTime.Now;
            Description = description;
        }
        
        
    }
}