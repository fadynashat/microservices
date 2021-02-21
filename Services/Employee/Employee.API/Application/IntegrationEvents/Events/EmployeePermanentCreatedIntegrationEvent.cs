namespace FADY.Services.Employee.API.Application.IntegrationEvents.Events
{
    using FADY.BuildingBlocks.EventBus.Events;
  

    public class EmployeePermanentCreatedIntegrationEvent : IntegrationEvent
    {
        public int EmpId { get; set; }

        public EmployeePermanentCreatedIntegrationEvent(int _empId) =>
            EmpId = _empId;
}    }

