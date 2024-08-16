using System;
using System.Collections.Generic;
public class PatientServices:IAppointmentServices
{
	IPatientRepository _patientrepo;
	public PatientServices(IPatientRespository _patient)
	{
		_patientrepo = _patient;
	}
	public void CreateAppointment(Token token)
	{

	}
	public List<AppointmentResponseModel> GetAppointments(int id)
	{

	}

}


