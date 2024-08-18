using System;

public class DoctorDBModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Gender { get; set; }
	public DateTime Joiningdate { get; set; }
	public int patientstreated { get; set; }
	public int DeptId { get; set; }
}

public class DoctorDemoModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public DateTime Joiningdate { get; set; }
    public int patientstreated { get; set; }
    public int DeptId { get; set; }
    public DateTime slotdate { get; set; }

}

