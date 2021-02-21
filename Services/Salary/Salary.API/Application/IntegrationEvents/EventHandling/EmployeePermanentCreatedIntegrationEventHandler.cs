using FADY.Services.Salary.API.Application.IntegrationEvents.Events;
using FADY.BuildingBlocks.EventBus.Abstractions;

using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Threading.Tasks;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using FADY.Services.Salary.API;
using FADY.Services.Salary.Infrastructure.Repository;
using System.Threading;

namespace FADY.Services.Salary.API.Application.IntegrationEvents.EventHandling
{
    public class EmployeePermanentCreatedIntegrationEventHandler : IIntegrationEventHandler<EmployeePermanentCreatedIntegrationEvent>
    {
        private readonly ISalaryRepository _repository;
        private readonly ILogger<EmployeePermanentCreatedIntegrationEventHandler> _logger;

        //public EmployeePermanentCreatedIntegrationEventHandler(
        //    ISalaryRepository repository,
        //    ILogger<EmployeePermanentCreatedIntegrationEventHandler> logger)
        //{
        //   _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        public EmployeePermanentCreatedIntegrationEventHandler(ISalaryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task Handle(EmployeePermanentCreatedIntegrationEvent @event)
        {
            
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
               // _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);
                var empsalary = new salary(@event.EmpId, 1000.00);
                _repository.Add(empsalary);
                 await _repository.UnitOfWork
                .SaveEntitiesAsync();

            }
        }
    }
}



