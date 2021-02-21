using FADY.BuildingBlocks.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.IntegrationEvents
{
    public interface IEmployeeIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
