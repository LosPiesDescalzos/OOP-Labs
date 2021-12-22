using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/Employees")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Create")]
        public Employee Create([FromQuery] string name)
        {
            return _service.Create(name);
        }

        [HttpGet]
        [Route("FindEmployee")]
        public IActionResult Find([FromQuery] string name, [FromQuery] Guid id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Employee result = _service.FindByName(name);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            if (id != Guid.Empty)
            {
                Employee result = _service.FindById(id);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpPost]
        [Route("DeleteEmployee")]
        public void Delete([FromQuery] Guid id)
        {
            _service.Delete(id);
        }
        
        [HttpPost]
        [Route("AddEmployeeToSupervisor")]
        public void AddEmployeeToSupervisor([FromQuery] Guid idSupervisor, Guid idEmployee)
        {
            _service.AddEmployeeToSupervisor(idSupervisor, idEmployee);
        }
        
    }
}