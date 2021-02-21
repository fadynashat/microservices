using MediatR;
using FADY.BuildingBlocks.EventBus.Abstractions;
using FADY.BuildingBlocks.EventBus.Extensions;
using Microsoft.Extensions.Logging;
using FADY.Services.Employee.API.Application.Commands;
using FADY.Services.Employee.API.Application.IntegrationEvents.Events;
using Serilog.Context;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.IntegrationEvents.EventHandling
{
    public class EmployeePermanentCreatedIntegrationEventHandler : IIntegrationEventHandler<EmployeePermanentCreatedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeePermanentCreatedIntegrationEventHandler> _logger;

        public EmployeePermanentCreatedIntegrationEventHandler(
            IMediator mediator,
            ILogger<EmployeePermanentCreatedIntegrationEventHandler> logger)
        {
            _mediator = mediator;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }
      



        /// <summary>
        /// Event handler which confirms that the grace period
        /// has been completed and order will not initially be cancelled.
        /// Therefore, the order process continues for validation. 
        /// </summary>
        /// <param name="event">       
        /// </param>
        /// <returns></returns>
        public async Task Handle(EmployeePermanentCreatedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                var command = new CreateEmployeePermanentCommand(@event.EmpId);

                _logger.LogInformation(
                    "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                    command.GetGenericTypeName(),
                    nameof(command.EmpId),
                    command.EmpId,
                    command);

                await _mediator.Send(command);
            }
        }
    }
}
