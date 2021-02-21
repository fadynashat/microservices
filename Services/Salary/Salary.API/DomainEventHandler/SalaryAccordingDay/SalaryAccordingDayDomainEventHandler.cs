using MediatR;
using Salaary.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;

namespace FADY.Services.Salary.API.DomainEventHandler.SalaryAccordingDay
{
    public class SalaryAccordingDayDomainEventHandler : INotificationHandler<SalaryAccordingDayDomainEvent>
    {
        private readonly ISalaryRepository SalaryRepository;

        public SalaryAccordingDayDomainEventHandler(ISalaryRepository _SalaryRepository)
        {
            SalaryRepository = _SalaryRepository ?? throw new ArgumentNullException(nameof(_SalaryRepository));


        }

        public async Task Handle(SalaryAccordingDayDomainEvent notification, CancellationToken cancellationToken)
        {
            var NumOfDays = notification.attendance.days;

            var SalaryFromEvent =Int32.Parse(NumOfDays) * 150;

            var Salary = new Salary.Dmoain.AggregatesModel.SalaryAggregate.salary(1, SalaryFromEvent);


            SalaryRepository.Add(Salary);




        }


    }
}
