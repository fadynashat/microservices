using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FADY.Services.Employee.API.Application.Queries;
using FADY.Services.Employee.API.Application.Commands;
using FADY.Services.Employee.API.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System.Net;

namespace FADY.Services.Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmployeeQueries _employeeQueries;
        private readonly IIdentityService _identityService;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IMediator mediator,
            IEmployeeQueries employeeQueries,
            IIdentityService identityService,
            ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _employeeQueries = employeeQueries ?? throw new ArgumentNullException(nameof(employeeQueries));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
        }   




        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employe>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get()
        {
            var result = await _employeeQueries.GetAllEmployeeAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employe), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _employeeQueries.GetEmployeeAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(CreateEmployeePermanentCommand employeeCommand)
        {
            return Ok(await _mediator.Send(employeeCommand));
        }



        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] UpdateEmployeePermanentCommand employeeCommand)
        {
            return Ok(await _mediator.Send(employeeCommand));

        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(UpdateEmployeePermanentCommand employeeCommand)
        {
            return Ok(await _mediator.Send(employeeCommand));

        }
    }
}
