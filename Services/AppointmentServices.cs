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
	public void CreateAppointment(AppointmentRequestModel _appointment)
	{
		var _appointmentDBModel = new AppointmentDBModel()
		{
			PatientId = _appointment.PatientId,
			AllotedDate = _appointment.DateAlloted,
			DoctorId = _appointment.DoctorId,
			StartTime = _appointment.StartTime,
			EndTime = _appointment.EndTime
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
			AllotedDate=x.AllotedDate,
			StartTime=x.StartTime,
			EndTime=x.EndTime
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
}


