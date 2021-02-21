using Microsoft.EntityFrameworkCore;
using FADY.BuildingBlocks.EventBus.Abstractions;
using FADY.BuildingBlocks.EventBus.Events;
using FADY.BuildingBlocks.IntegrationEventLogEF;
using FADY.BuildingBlocks.IntegrationEventLogEF.Services;
using FADY.Services.Employee.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.IntegrationEvents
{
    public class EmployeeIntegrationEventService : IEmployeeIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly EmployeeContext _EmployeeContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<EmployeeIntegrationEventService> _logger;

        public EmployeeIntegrationEventService(IEventBus eventBus,
            EmployeeContext EmployeeContext,
            IntegrationEventLogContext eventLogContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
            ILogger<EmployeeIntegrationEventService> logger)
        {
            _EmployeeContext = EmployeeContext ?? throw new ArgumentNullException(nameof(EmployeeContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_EmployeeContext.Database.GetDbConnection());
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PublishEventsThroughEventBusAsync(Guid transactionId)
        {
            var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);

            foreach (var logEvt in pendingLogEvents)
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", logEvt.EventId, Program.AppName, logEvt.IntegrationEvent);

                try
                {
                    await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                    _eventBus.Publish(logEvt.IntegrationEvent);
                    await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "ERROR publishing integration event: {IntegrationEventId} from {AppName}", logEvt.EventId, Program.AppName);

                    await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
                }
            }
        }

        public async Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("----- Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", evt.Id, evt);

            await _eventLogService.SaveEventAsync(evt, _EmployeeContext.GetCurrentTransaction());
        }
    }
}
