using System;
using System.Collections.Generic;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IReportService
    {
        void SerializeReport(List<Report> tasks);
        List<Report> DeSerializeReport();
        Report Create(string description);
        void AddTaskToReport(Guid taskId, Guid reportId);
        void AddEmployeeToReport(Guid employeeId, Guid reportId);
        void SaveReport(Guid reportId); 
        List<Report> FindClosedReports(Guid employeeId);
        List<Report> FindOpenReports(Guid employeeId);
        

    }
}