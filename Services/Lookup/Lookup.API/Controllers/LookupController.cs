using FADY.Services.Lookup.API.IntegrationEvents.Events;
using FADY.Services.Lookup.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FADY.BuildingBlocks.EventBus.Abstractions;
using FADY.Services.Lookup.API.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using lookup.API.Model;
using Dapper;
using System.Data.SqlClient;
using System.Text.Json;
using Nancy.Json;

using lookup.API.Infrastructure.Helper;
using Lookup.API.Model;
using System.Collections.Generic;

namespace FADY.Services.Lookup.API.Controllers
{
    [Route("api/v1/[controller]")]
    //[Authorize]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupTRepository _repository;
     //   private readonly IIdentityService _identityService;
        private readonly IEventBus _eventBus;
        private readonly ILogger<LookupController> _logger;

        public LookupController(
            ILogger<LookupController> logger,
            ILookupTRepository repository,
         //   IIdentityService identityService,
            IEventBus eventBus)
        {
            _logger = logger;
            _repository = repository;
          //  _identityService = identityService;
            _eventBus = eventBus;
        }
      
        [HttpGet]
        [ProducesResponseType(typeof(LookupItems), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LookupT>> Get(string lookupname, int code)
        {
            var Lookup = await _repository.GetLookupItemAsync(lookupname,code);

            return Ok(Lookup);
        }


        [HttpGet("{lookupname}")]
        [ProducesResponseType(typeof(IEnumerable<LookupItems>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LookupItems>>> Get(string lookupname)
        {
            var Lookup = await _repository.GetLookupItems(lookupname);

            return Ok(Lookup);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateLookupItemAsync(string LookupName, int Code, string Name)
        {
           // var userId = _identityService.GetUserIdentity();
            var Lookup = await _repository.GetLookupItemAsync(LookupName, Code);

            if (Lookup == null)
            {
                return BadRequest();
            }
            //update value in redis memory 
            //publish event 
            var eventMessage = new LookupItemChangedIntegrationEvent(LookupName, Code, Name);
            try
            {
                _eventBus.Publish(eventMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName}", eventMessage.Id, Program.AppName);

                throw;
            }
            // Once Lookup is change, sends an integration event to
            // all api to change Lookup   value and proceeds with
            //self consume integration event
            //update in sql server



            return Accepted();
        }

        // DELETE api/values/5
        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteLookupByIdAsync(string lookupname,int code)
        {
            await _repository.DeleteLookupItemAsync(lookupname, code);
        }

       
    }
}
