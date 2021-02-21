using MediatR;
using FADY.Services.Employee.Dmoain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;

namespace FADY.Services.Employee.API.DomainEventHandler.EmployeePermanent
{
    public class EmployeePermanentDomainEventHandler : INotificationHandler<EmployeePermanentDomainEvent>
    {
        private readonly IEmployeeRepository EmployeeRepository;

        public EmployeePermanentDomainEventHandler(IEmployeeRepository _EmployeeRepository)
        {
            EmployeeRepository = _EmployeeRepository ?? throw new ArgumentNullException(nameof(_EmployeeRepository));


        }

        public async Task Handle(EmployeePermanentDomainEvent notification, CancellationToken cancellationToken)
        {
        

            var Employee = new Employee.Dmoain.AggregatesModel.EmployeeAggregate.Employe();


            EmployeeRepository.Add(Employee);




        }


    }
}
