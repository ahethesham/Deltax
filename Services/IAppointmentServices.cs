using System.Collections.Generic;
public interface IAppointmentServices
{
    public void CreateAppointment(AppointmentRequestModel _appointment);
    public List<AppointmentResponseModel> GetAppointments(int id);
}

