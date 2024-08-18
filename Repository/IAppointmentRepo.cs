using System;
using System.Collections.Generic;

public interface IAppointmentRepo
{
    public void CreateAppointment(AppointmentDBModel _appointment);
    public List<AppointmentDBModel> GetAppointments(int id);
    public TimeSpan GetTime(int id);
    public TimeSpan GetEndTime(int id);
    public string GetDate(int id);
}


