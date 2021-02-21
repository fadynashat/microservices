using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;

namespace FADY.Services.Employee.Dmoain.Events
{
    public class EmployeePermanentDomainEvent : INotification
    {
        public Employe Employe{ get; }

        public EmployeePermanentDomainEvent(Employe _employe)
        {
            Employe= _employe;
        }
    }
}
