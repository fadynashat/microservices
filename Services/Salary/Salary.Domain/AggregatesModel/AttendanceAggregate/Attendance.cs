using Salaary.Domain.Events;
using FADY.Services.Salary.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADY.Services.Salary.Domain.AggregatesModel.AttendanceAggregate
{
    public class Attendance : Entity, IAggregateRoot
    {
        public string days { get; private set; }

        public Attendance()
        {

        }

     

        public Attendance(string day)
        {
            days = day;
            AddAttandanceStartedDomainEvent();
        }


        public void UpdateAttandce(string day)
        {
            days = day;
        }

        private void AddAttandanceStartedDomainEvent()
        {
            var salaryStoredDomainEvent = new SalaryAccordingDayDomainEvent(this); 

            this.AddDomainEvent(salaryStoredDomainEvent);
        }

    }
}
