using MediatR;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FADY.Services.Employee.API.Application.IntegrationEvents;
using Microsoft.Extensions.Logging;
using FADY.Services.Employee.API.Application.IntegrationEvents.Events;
using FADY.Services.Employee.API.Infrastructure.Services;

namespace FADY.Services.Employee.API.Application.Commands
{
    public class CreateEmployeePermanentCommandHandler : IRequestHandler<CreateEmployeePermanentCommand, bool>
    {
        private readonly IEmployeeRepository _Repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IEmployeeIntegrationEventService _employeeIntegrationEventService;
         private readonly IIdentityService _identityService;
        private readonly ILogger<CreateEmployeePermanentCommandHandler> _logger;

            // Using DI to inject infrastructure persistence Repositories
            public CreateEmployeePermanentCommandHandler(IMediator mediator,
                IEmployeeIntegrationEventService employeeIntegrationEventService,
                IEmployeeRepository employeeRepository,
                IIdentityService identityService,
                ILogger<CreateEmployeePermanentCommandHandler> logger)
            {
                 _Repository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                 _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
                 _employeeIntegrationEventService = employeeIntegrationEventService ?? throw new ArgumentNullException(nameof(employeeIntegrationEventService));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task<bool> Handle(CreateEmployeePermanentCommand request, CancellationToken cancellationToken)
        {

            // Add Integration event to clean the basket
            var employeePermanentCreatedIntegrationEvent = new EmployeePermanentCreatedIntegrationEvent(request.EmpId);
            await _employeeIntegrationEventService.AddAndSaveEventAsync(employeePermanentCreatedIntegrationEvent);

            var Employee = new Dmoain.AggregatesModel.EmployeeAggregate.Employe(request.EmpId,
                  request.Name,
                request.Address,
                request.Phone
                );
            _Repository.Add(Employee);
       

            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
