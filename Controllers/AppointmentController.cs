using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


[ApiController]
[Route("patients")]
public class AppointmentsController : ControllerBase
{
   
    [HttpPost]
    [Route("/appointments")]
    public IActionResult CreateAppointment([FromBody]AppointmentRequestModel _appointment)
    {
        return Ok();
    }
    [HttpGet]
    [Route("/appointments/{id}")]
    public IActionResult GetAppointments(int id)
    {
        try
        {
            return Ok();
        }
        catch{
            return BadRequest();
        }
    }
        
}


