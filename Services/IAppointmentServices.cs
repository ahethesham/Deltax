﻿using System.Collections.Generic;
using System;
public interface IAppointmentServices
{
    public void CreateAppointment(AppointmentRequestModel _appointment);
    public List<AppointmentResponseModel> GetAppointments(int id);
    public DoctorDemoModel GetBestDoctor(int DeptId, DateTime date);
}

