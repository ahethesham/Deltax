using System;

public class AppointmentDBModel
{
	public int PatientId { get; set; }
	public int DoctorId { get; set; }
	//public int Id { get; set; }
	public string AllotedDate { get; set; }
	public TimeSpan StartTime { get; set; }
	public TimeSpan EndTime { get; set; }
}


