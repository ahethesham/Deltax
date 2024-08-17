
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using MySql.Data.MySqlClient;
public class DoctorRepo:IDoctorRepo
{
	private readonly string _connstring;
	public DoctorRepo(IOptions<ConnectionString> _connectionstring)
	{
		_connstring = _connectionstring.Value.Connectionstring;
	}
    public DoctorDBModel CheckExperience(int DeptId,DateTime date)
    {
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId FROM (doctor d       JOIN Workingslots ws ON d.id = ws.Doctorid) JOIN Slots s2 ON ws.slotid = s2.id WHERE YEAR(@date) - YEAR(d.Joiningdate) >= 10   AND d.DeptId = @DeptId  AND s2.slotdate = @date;";
            var response = conn.Query<DoctorDBModel>(sql, new { DeptId = DeptId, date = date }).ToList<DoctorDBModel>();
            if (response.Count == 0) return null;
            return response[0];
        }
    }
    public DoctorDBModel CheckPatientsTreated(int DeptId,DateTime date)
    {
        using(var conn=new MySqlConnection(_connstring))
        {
            var sql = "SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId  FROM doctor d  JOIN Workingslots s ON d.id = s.Doctorid JOIN Slots s2 ON s.slotid = s2.id WHERE d.patientstreated >= 20    AND d.DeptId = @DeptId    AND s2.slotdate = @date;";
            var response = conn.Query<DoctorDBModel>(sql, new { DeptId = DeptId,date=@date }).ToList<DoctorDBModel>();
            if (response.Count == 0) return null;
            return response[0];
        }

    }
    public DoctorDBModel GetNearestDoctor(int DeptId,DateTime date)
    {
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "SELECT d.Id, d.Name, d.Joiningdate, d.patientstreated, d.DeptId FROM doctor d JOIN Workingslots s ON d.id = s.Doctorid JOIN Slots s2 ON s.slotid = s2.id WHERE d.patientstreated >= 20  AND d.DeptId = @DeptId ORDER BY s2.slotdate DESC;";
            var response = conn.Query<DoctorDBModel>(sql, new { DeptId = DeptId, date = @date }).ToList<DoctorDBModel>();
            if (response.Count == 0) return null;
            return response[0];
        }
    }

	public string getname(int id)
    {
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select name from doctor where id=@Id";
			var res=conn.Query<string>(sql, new { Id = id }).ToList<string>();
			if (res.Count == 0) return "";
			return res[0];
        }
	}
	public string getdept(int id)
	{
        using (var conn = new MySqlConnection(_connstring))
        {
            var sql = "select name from department where id in(select deptid from doctor where id=@Id)";
            var res = conn.Query<string>(sql, new { Id = id }).ToList<string>();
            if (res.Count == 0) return "";
            return res[0];
        }
    }
}


