using FADY.BuildingBlocks.EventBus.Abstractions;
using FADY.Services.Lookup.API.IntegrationEvents.Events;
using FADY.Services.Lookup.API.Model;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Lookup.API.IntegrationEvents.EventHandling
{
    public class LookupItemChangedIntegrationEventHandler : IIntegrationEventHandler<LookupItemChangedIntegrationEvent>
    {
        private readonly ILogger<LookupItemChangedIntegrationEventHandler> _logger;
        private readonly ILookupTRepository _repository;

        public LookupItemChangedIntegrationEventHandler(
            ILogger<LookupItemChangedIntegrationEventHandler> logger,
            ILookupTRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(LookupItemChangedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                 //get table from event lookup name 
                 //update record in table from event data with reposity
            }
        }

    
    }
}

