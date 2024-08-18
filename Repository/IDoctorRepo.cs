using System;
using System.Collections.Generic;
public interface IDoctorRepo
{
	public string getname(int id);
	public string getdept(int id);
	public DoctorDBModel CheckExperience(int DeptId, DateTime date);
	public DoctorDBModel CheckPatientsTreated(int DeptId, DateTime date);
	public DoctorDBModel GetNearestDoctor(int DeptId, DateTime date);
	public List<DoctorDemoModel> GetAllDoctors(int deptid, DateTime date);

}


