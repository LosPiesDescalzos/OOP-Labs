using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{ 
    [ApiController]
    [Route("/Reports")]
    public class ReportController : ControllerBase
    {
       
        private IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("Create")]
        public Report Create([FromQuery] string description)
        {
            return _service.Create(description);
        }
        
        [HttpGet]
        [Route("FindClosedReports")]
        public IActionResult FindClosedReports([FromQuery] Guid employeeId)
        {
            if (employeeId != Guid.Empty)
            {
                List<Report> result = _service.FindClosedReports(employeeId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpGet]
        [Route("FindOpenReports")]
        public IActionResult FindOpenReports([FromQuery] Guid employeeId)
        {
            if (employeeId != Guid.Empty)
            {
                List<Report> result = _service.FindOpenReports(employeeId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("AddEmployeeToReport")]
        public void AddEmployeeToReport([FromQuery] Guid employeeId, Guid reportId)
        {
            if ((employeeId != Guid.Empty) && (reportId != Guid.Empty))
            {
                _service.AddEmployeeToReport(employeeId, reportId);
            }
        }
        
        [HttpPost]
        [Route("AddTaskToReport")]
        public void AddTaskToReport([FromQuery] Guid taskId, Guid reportId)
        {
            if ((taskId != Guid.Empty) && (reportId != Guid.Empty))
            {
                _service.AddTaskToReport(taskId, reportId);
            }
        }
        
        [HttpPost]
        [Route("SaveReport")]
        public void SaveReport([FromQuery] Guid reportId)
        {
            if (reportId != Guid.Empty)
            {
                _service.SaveReport(reportId);
            }
        }
        
    }
}