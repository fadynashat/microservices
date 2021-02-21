using FADY.BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Webhooks.API.Model;
using Webhooks.API.Services;

namespace Webhooks.API.IntegrationEvents
{
    public class EmployeeVacationChangedToApprovedIntegrationEventHandler : IIntegrationEventHandler<EmployeeVacationChangedToApprovedIntegrationEvent>
    {
        private readonly IWebhooksRetriever _retriever;
        private readonly IWebhooksSender _sender;
        private readonly ILogger _logger;
        public EmployeeVacationChangedToApprovedIntegrationEventHandler(IWebhooksRetriever retriever, IWebhooksSender sender, ILogger<EmployeeVacationChangedToApprovedIntegrationEventHandler> logger)
        {
            _retriever = retriever;
            _sender = sender;
            _logger = logger;
        }

        public async Task Handle(EmployeeVacationChangedToApprovedIntegrationEvent @event)
        {
            var subscriptions = await _retriever.GetSubscriptionsOfType(WebhookType.VacationApproved);
            _logger.LogInformation("Received EmployeeVacationChangedToApprovedIntegrationEvent and got {SubscriptionsCount} subscriptions to process", subscriptions.Count());
            var whook = new WebhookData(WebhookType.VacationApproved, @event);
            await _sender.SendAll(subscriptions, whook);
        }
    }
}
