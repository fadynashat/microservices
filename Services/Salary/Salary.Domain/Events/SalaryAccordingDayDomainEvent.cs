using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using FADY.Services.Salary.Domain.AggregatesModel.AttendanceAggregate;

namespace Salaary.Domain.Events
{
   public class SalaryAccordingDayDomainEvent : INotification
    {
        public Attendance attendance { get; }

        public SalaryAccordingDayDomainEvent(Attendance _attendance)
        {
            attendance = _attendance;
        }
    }
    
}
