using System;

public class AppointmentRequestModel
{
	public int PatientId { get; set; }
	public int DoctorId { get; set; }
	public string DateAlloted { get; set; }
	public string StartTime { get; set; }
	public string EndTime { get; set; }
}