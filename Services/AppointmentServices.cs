using System;
using System.Collections.Generic;
using System.Linq;

public class AppointmentServices:IAppointmentServices
{
	IAppointmentRepo _appointmentrepo;
	IDoctorRepo _doctorrepo;
	public AppointmentServices(IAppointmentRepo _appointment,IDoctorRepo _doctor)
	{
		_appointmentrepo=_appointment;
		_doctorrepo = _doctor;
	}

	public DoctorDemoModel GetBestDoctor(int Deptid,DateTime date)
	{
		DoctorDemoModel response;
		response = CheckExperience(Deptid, date);
		if (response != null) return response;
		response = CheckPatientsTreated(Deptid, date);
		if(response!=null)
		return response;
		var alldocs = _doctorrepo.GetAllDoctors(Deptid, date);
		if (alldocs.Count == 0) return null;
		for(int i = 0; i < alldocs.Count; i++)
		{
			int y1 = alldocs[i].Joiningdate.Year, y2 = date.Year;
			if (y2 - y1 >= 10)
				return alldocs[i];
		}
		
        for (int i = 0; i < alldocs.Count; i++)
        {
			if (alldocs[i].patientstreated >= 20) return alldocs[i];
        }
		return null;
        //return GetNearest(Deptid, date);
    }

	private DoctorDemoModel CheckExperience(int deptId,DateTime date)
	{
		var response=_doctorrepo.CheckExperience(deptId, date);
		if (response == null) return null;
		var res = new DoctorDemoModel()
		{
			Name = response.Name,
			Id = response.Id,
			Joiningdate = response.Joiningdate,
			patientstreated = response.patientstreated,
			Gender = response.Gender,
			slotdate = date
		};
		return res;
	}
	private DoctorDemoModel CheckPatientsTreated(int deptid,DateTime date)
	{
		var response=_doctorrepo.CheckPatientsTreated(deptid, date);
        if (response == null) return null;
		var res = new DoctorDemoModel()
		{
			Name = response.Name,
			Id = response.Id,
			Joiningdate = response.Joiningdate,
			patientstreated = response.patientstreated,
			Gender = response.Gender,
			slotdate = date
        };
		return res;
    }
	private DoctorDemoModel GetNearest(int deptid,DateTime date)
	{
		var response=_doctorrepo.GetNearestDoctor(deptid, date);
        if (response == null) return null;
        var res = new DoctorDemoModel()
        {
            Name = response.Name,
            Id = response.Id,
            Joiningdate = response.Joiningdate,
            patientstreated = response.patientstreated,
            Gender = response.Gender,
			slotdate=date
        };
		return res;
    }


	public void CreateAppointment(AppointmentRequestModel _appointment)
	{
		var _appointmentDBModel = new AppointmentDBModel()
		{
			PatientId = _appointment.PatientId,
			SlotId = _appointment.SlotId,
			DoctorId = _appointment.DoctorId,
			
		};
		_appointmentrepo.CreateAppointment(_appointmentDBModel);

	}
	public List<AppointmentResponseModel> GetAppointments(int id)
	{
		var list = _appointmentrepo.GetAppointments(id);
		var resp = list.Select(x => new AppointmentResponseModel()
		{
			PatientId = x.PatientId,
			DoctorName = GetDoctorName(x.DoctorId),
			Department=GetDepartment(x.DoctorId),
			AllotedDate=GetDate(x.SlotId),
			StartTime=GetTime(x.SlotId),
			EndTime=GetEndTime(x.SlotId)
		}).ToList();
		return resp;
	}

	private string GetDoctorName(int id)
	{
		var name = _doctorrepo.getname(id);
		return name;
	}
	private  string GetDepartment(int id)
	{
		var dept = _doctorrepo.getdept(id);
		return dept;
	}
	private string GetDate(int id)
	{
		return _appointmentrepo.GetDate(id);
	}
    private TimeSpan GetTime(int id)
    {
        return _appointmentrepo.GetTime(id);
    }
    private TimeSpan GetEndTime(int id)
    {
        return _appointmentrepo.GetEndTime(id);
    }

}


