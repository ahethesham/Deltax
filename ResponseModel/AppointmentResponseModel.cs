using System;

public class AppointmentResponseModel
{
	public int PatientId { get; set; }
	public string DoctorName { get; set; }
	public string Department { get; set; }
	public string AllotedDate { get; set; }
	public TimeSpan StartTime { get; set; }
	public TimeSpan EndTime { get; set; }
}


