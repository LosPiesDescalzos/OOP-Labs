using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/Tasks")]
    public class TaskController : ControllerBase
    {
        private ITaskService _service;
        
        public TaskController(ITaskService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("Create")]
        public Task Create([FromQuery] string name, string description)
        {
            return _service.Create(name, description);
        }
        
        [HttpGet]
        [Route("FindById")]
        public IActionResult Find([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                Task result = _service.FindById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpPost]
        [Route("AddEmployeeToTask")]
        public void AddEmployeeToTask([FromQuery] Guid idEmployee, Guid idTask)
        {
            if ((idEmployee != Guid.Empty) && (idTask != Guid.Empty))
            {
                _service.AddEmployeeToTask(idEmployee, idTask);
            }
        }

        [HttpPost]
        [Route("AddComments")]
        public void AddComments([FromQuery] Guid taskId, string comment)
        {
            if ((taskId != Guid.Empty) && (comment != null))
            {
                _service.AddComments(taskId, comment);
            }
        }



        [HttpGet]
        [Route("FindByLastChange")]
        public IActionResult FindByLastChange([FromQuery] DateTime date)
        {
            if (date != default)
            {
                List<Task> result = _service.FindByLastChange(date);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpGet]
        [Route("FindByDateCreate")]
        public IActionResult FindByDateCreate([FromQuery] DateTime date)
        {
            if (date != default)
            {
                List<Task> result = _service.FindByDateCreate(date);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpGet]
        [Route("FindByEmployee")]
        public IActionResult FindByEmployee([FromQuery] Guid idEmployee)
        {
            if (idEmployee != Guid.Empty)
            {
                List<Task> result = _service.FindByEmployee(idEmployee);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpGet]
        [Route("FindByChange")]
        public IActionResult FindByChange([FromQuery] Guid taskId)
        {
            if (taskId != Guid.Empty)
            {
                List<Task> result = _service.FindByChange(taskId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpPost]
        [Route("ResolveTask")]
        public void ResolveTask([FromQuery] Guid taskId)
        {
            _service.ResolveTask(taskId);
        }
    }
}