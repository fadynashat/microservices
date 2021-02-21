using FADY.BuildingBlocks.EventBus.Events;
using System.Collections.Generic;

namespace Webhooks.API.IntegrationEvents
{
    public class EmployeeVacationChangedToApprovedIntegrationEvent : IntegrationEvent
    {
        public int EmpId { get; }
        public int Numofdays { get; }

        public EmployeeVacationChangedToApprovedIntegrationEvent(int empid,int numofdays)
        {
            EmpId = empid;
            Numofdays = numofdays;
        }
    }

   
}
