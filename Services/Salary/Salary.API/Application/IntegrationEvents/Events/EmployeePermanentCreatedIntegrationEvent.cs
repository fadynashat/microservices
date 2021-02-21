using FADY.BuildingBlocks.EventBus.Events;
using System.Threading;

namespace FADY.Services.Salary.API.Application.IntegrationEvents.Events
{
    // Integration Events notes: 
    // An Event is “something that has happened in the past”, therefore its name has to be   
    // An Integration Event is an event that can cause side effects to other microsrvices, Bounded-Contexts or external systems.
    public class EmployeePermanentCreatedIntegrationEvent : IntegrationEvent
    {
        public int EmpId { get; set; }

        public EmployeePermanentCreatedIntegrationEvent(int empId)
            => EmpId = empId;
    }
}
