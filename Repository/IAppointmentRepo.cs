using System;
using System.Collections.Generic;

public interface IAppointmentRepo
{
    public void CreateAppointment(AppointmentDBModel _appointment);
    public List<AppointmentDBModel> GetAppointments(int id);
}


