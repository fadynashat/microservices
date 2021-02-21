using FADY.BuildingBlocks.EventBus.Events;

namespace FADY.Services.Lookup.API.IntegrationEvents.Events
{
    // Integration Events notes: 
    // An Event is “something that has happened in the past”, therefore its name has to be   
    // An Integration Event is an event that can cause side effects to other microsrvices, Bounded-Contexts or external systems.
    public class LookupItemChangedIntegrationEvent : IntegrationEvent
    {
        public string LookupName { get; private init; }
 

        public int Code { get; private init; }

        public string Name { get; private init; }

        public LookupItemChangedIntegrationEvent(string lookupName,  int code, string name)
        {
            LookupName = lookupName;
      
            Code = code;
            Name = name;
        }
    }
}
