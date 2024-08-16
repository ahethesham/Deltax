using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using System.Linq;

public class AppointmentRepo:IAppointmentRepo
{
    private readonly string _connstring;
    public AppointmentRepo(IOptions<ConnectionString> _connectionstring)
    {
        _connstring = _connectionstring.Value.Connectionstring;
    }
    public void CreateAppointment(AppointmentDBModel _appointment)
	{
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "Insert into Appointments(patientid,doctorid,alloteddate,starttime,endtime) values(@PatientId,@DoctorId,@Alloteddate,@startTime,@EndTime)";
            conn.Execute(sql, new { PatientId = _appointment.PatientId,DoctorId=_appointment.DoctorId,Alloteddate=_appointment.AllotedDate,
                startTime=_appointment.StartTime,EndTime=_appointment.EndTime });
            return;
        }
    }
	public List<AppointmentDBModel> GetAppointments(int id)
	{
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select PatientId,DoctorId,AllotedDate,StartTime,EndTime from Appointments where Patientid=@Id";
            var res = conn.Query<AppointmentDBModel>(sql, new { Id = id }).ToList<AppointmentDBModel>();
            return res; 
        }
    }
}


