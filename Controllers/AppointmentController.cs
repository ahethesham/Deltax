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
    IAppointmentServices _appointmentservices;
    public AppointmentsController(IAppointmentServices _appointment)
    {
        _appointmentservices = _appointment;
    }
    
    [HttpPost]
    [Route("appointments")]
    public IActionResult CreateAppointment([FromBody]AppointmentRequestModel _appointment)
    {
       // try
        //{
            _appointmentservices.CreateAppointment(_appointment);
            return Ok();
        //}
        //catch(Exception e)
        //{
          //  return BadRequest(e);
        //}
    }
    [HttpGet]
    [Route("appointments/{id}")]
    public IActionResult GetAppointments(int id)
    {
       // try
        //{
            return Ok(_appointmentservices.GetAppointments(id));
        //}
        //catch(Exception e){
        //    return BadRequest(e);
        //}
    }
    [HttpGet]
    [Route("BestDoctor")]
    public IActionResult GetBestDoctor([FromBody]BestDoctor _bestdoctor)
    {
        //try
        //{
            return Ok(_appointmentservices.GetBestDoctor(_bestdoctor.DeptId, _bestdoctor.date));
        //}
        //catch(Exception e)
        //{
        //    return BadRequest(e);
        //}
    }
        
}


