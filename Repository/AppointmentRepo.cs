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
            var sql = "Insert into Appointments(patientid,doctorid,SlotId) values(@PatientId,@DoctorId,@SlotId)";
            conn.Execute(sql, new { PatientId = _appointment.PatientId,DoctorId=_appointment.DoctorId,SlotId=_appointment.SlotId });
            return;
        }
    }
	public List<AppointmentDBModel> GetAppointments(int id)
	{
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select PatientId,DoctorId,SlotId from Appointments where Patientid=@Id";
            var res = conn.Query<AppointmentDBModel>(sql, new { Id = id }).ToList<AppointmentDBModel>();
            return res; 
        }
    }
    public TimeSpan GetTime(int id)
    {
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select starttime from slots where id =@Id";
            var res = conn.Query<TimeSpan>(sql, new { Id = id }).ToList<TimeSpan>();
            return res[0];
        }

    }
    public TimeSpan GetEndTime(int id)
    {
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select endtime from slots where id =@Id";
            var res = conn.Query<TimeSpan>(sql, new { Id = id }).ToList<TimeSpan>();
            return res[0];
        }
    }
    public string GetDate(int id)
    {
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select slotdate from slots where id =@Id";
            var res = conn.Query<string>(sql, new { Id = id }).ToList<string>();
            return res[0];
        }
    }
}


