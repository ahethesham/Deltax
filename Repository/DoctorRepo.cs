
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
public class DoctorRepo:IDoctorRepo
{
	private readonly string _connstring;
	public DoctorRepo(IOptions<ConnectionString> _connectionstring)
	{
		_connstring = _connectionstring.Value.Connectionstring;
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


