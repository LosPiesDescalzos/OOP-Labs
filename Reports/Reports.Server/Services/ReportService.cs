using System;
using System.Collections.Generic;
using Reports.Server.Services;
using System.IO;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private string jsonPath = "reports.json";

        private TaskService _taskService = new TaskService();
        
        private EmployeeService _employeeService = new EmployeeService();
        private Repository<Report> repository = new Repository<Report>();

        public void SerializeReport(List<Report> reports)
        {
            repository.Serialize(reports, jsonPath);
        }
        
        public List<Report> DeSerializeReport()
        {
            return repository.DeSerialize(jsonPath);
        }
        
        public Report Create(string description)
        {
            Report report = new Report(Guid.NewGuid(), description);
            List<Report> reports = DeSerializeReport();
            if (reports == null)
            {
                reports = new List<Report>();
            }
            reports.Add(report);
            SerializeReport(reports);
            return report;
        }

        public void AddTaskToReport(Guid taskId, Guid reportId)
        {
            List<Report> reports = DeSerializeReport();
            if (reports == null)
            {
                reports = new List<Report>();
            }
            foreach (var report in reports)
            {
                if (report.Id == reportId)
                {
                    foreach (var task in _taskService.DeSerializeTask())
                    {
                        if (task.Id == taskId)
                        {
                            report.Tasks.Add(task);
                        }
                    }
                }
            }
            SerializeReport(reports);
        }

        public void AddEmployeeToReport(Guid employeeId, Guid reportId)
        {
            List<Report> reports = DeSerializeReport();
            if (reports == null)
            {
                reports = new List<Report>();
            }
            foreach (var report in reports)
            {
                if (report.Id == reportId)
                {
                    foreach (var employee in _employeeService.DeSerializeEmployee())
                    {
                        if (employee.Id == employeeId)
                        {
                            report.Employee = employee;
                        }
                    }
                }
            }
            SerializeReport(reports);
        }
        
        public void SaveReport(Guid reportId)
        {
            List<Report> reports = DeSerializeReport();
            if (reports == null)
            {
                reports = new List<Report>();
            }
            foreach (var report in reports)
            {
                if (report.Id == reportId)
                {
                    report.Status = ReportStatus.Closed;
                }
            }
            SerializeReport(reports);
        }


        public List<Report> FindClosedReports(Guid employeeId)
        {
            List<Report> reports = DeSerializeReport();
            if (reports == null)
            {
                reports = new List<Report>();
            }
            List<Report> closedReports = new List<Report>();
            foreach (var report in reports)
            {
                if (report.Employee != null)
                {
                    if ((report.Employee.Id == employeeId) && (report.Status == ReportStatus.Closed))
                    {
                        closedReports.Add(report);
                    }
                }
            }
            SerializeReport(reports);
            return closedReports;
        }
        
        public List<Report> FindOpenReports(Guid employeeId)
        {
            List<Report> reports = DeSerializeReport();
            if (reports == null)
            {
                reports = new List<Report>();
            }
            List<Report> openReports = new List<Report>();
            foreach (var report in reports)
            {
                if (report.Employee != null)
                {
                    if ((report.Employee.Id == employeeId) && (report.Status == ReportStatus.Open))
                    {
                        openReports.Add(report);
                    }
                }
            }
            SerializeReport(reports);
            return openReports;
        }
        
    }
}