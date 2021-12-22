using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private string jsonPath = "tasks.json";
        private EmployeeService _employeeService = new EmployeeService();
        private Repository<Task> repository = new Repository<Task>();

        
        public void SerializeTask(List<Task> tasks)
        {
            repository.Serialize(tasks, jsonPath);
        }
        
        public List<Task> DeSerializeTask()
        {
            return repository.DeSerialize(jsonPath);
        }

        public Task Create(string name, string description)
        {
            Task task = new Task(Guid.NewGuid(), name, description);
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            tasks.Add(task);
            SerializeTask(tasks);
            return task;
        }
        
        public void AddEmployeeToTask(Guid idEmployee, Guid idTask)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            foreach (var task in tasks)
            {
                if (task.Id == idTask)
                {
                    foreach (var employee in _employeeService.DeSerializeEmployee())
                    {
                        if (employee.Id == idEmployee)
                        {
                            task.Employee = employee;
                        }
                    }
                }
                SerializeTask(tasks);
            }
        }
        

        public Task FindById(Guid id)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            Task findTask = null;
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    findTask = task;
                }
            }
            SerializeTask(tasks);
            return findTask;
        }
        
        public List<Task> FindByLastChange(DateTime date)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            List<Task> DateTasks = null;
            foreach (var task in tasks)
            {
                if (task.LastChange >= date)
                {
                    DateTasks.Add(task);
                }
            }
            SerializeTask(tasks);
            return DateTasks;
        }
        
        public List<Task> FindByDateCreate(DateTime date)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            List<Task> DateTasks = new List<Task>();
            foreach (var task in tasks)
            {
                if (task.Create >= date)
                {
                    DateTasks.Add(task);
                }
            }
            SerializeTask(tasks);
            return DateTasks;
        }

        public void AddComments(Guid taskId, string comment)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>(); 
            }
            foreach (var task in tasks)
            {
                if (task.Id == taskId)
                {
                    task.Comments.Add(comment);
                }
            }
            SerializeTask(tasks);
        }
        

        public void ResolveTask(Guid taskId)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            foreach (var task in tasks)
            {
                if (task.Id == taskId)
                {
                    task.Status = TaskStatus.Resolved;
                }
            }
            SerializeTask(tasks);
        }
        
        
        
        public List<Task> FindByEmployee(Guid idEmployee)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            List<Task> EmployeeTasks = null;
            foreach (var task in tasks)
            {
                if (task.Employee != null)
                {
                    if (task.Employee.Id == idEmployee)
                    {
                        EmployeeTasks.Add(task);
                    }
                }
            }
            SerializeTask(tasks);
            return EmployeeTasks;
        }
        
        
        
        public List<Task> FindByChange(Guid taskId)
        {
            List<Task> tasks = DeSerializeTask();
            if (tasks == null)
            {
                tasks = new List<Task>();
            }
            List<Task> EmployeeTasks = null;
            foreach (var task in tasks)
            {
                if (task.Id == taskId)
                {
                    if (task.LastChange != default)
                    {
                        EmployeeTasks.Add(task);
                    }
                }
            }
            SerializeTask(tasks);
            return EmployeeTasks;
        }
        
    }
}