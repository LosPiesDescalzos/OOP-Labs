using System;
using System.Collections.Generic;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface ITaskService
    {
        void SerializeTask(List<Task> tasks);
        List<Task> DeSerializeTask();
        Task Create(string name, string description);
        void AddEmployeeToTask(Guid idEmployee, Guid idTask);
        Task FindById(Guid id);
        List<Task> FindByLastChange(DateTime date);
        List<Task> FindByDateCreate(DateTime date);
        void AddComments(Guid taskId, string comment);
        void ResolveTask(Guid taskId);
        List<Task> FindByEmployee(Guid idEmployee);
        List<Task> FindByChange(Guid taskId);
        
    }
}