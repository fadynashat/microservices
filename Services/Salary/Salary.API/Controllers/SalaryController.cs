using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using FADY.Services.Salary.API.Application.Queries;
using FADY.Services.Salary.API.Application.Commands;

namespace FADY.Services.Salary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISalaryQueries _SalaryQueries;

        public SalaryController(IMediator mediator, ISalaryQueries SalaryQueries)
        {
            _mediator = mediator;
            _SalaryQueries = SalaryQueries;
        }   




        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _SalaryQueries.GetAllSalaryAsync();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _SalaryQueries.GetSalaryAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(CreateSalaryPermanentCommand SalaryCommand)
        {
            return Ok(await _mediator.Send(SalaryCommand));
        }



        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] UpdateSalaryCommand SalaryCommand)
        {
            return Ok(await _mediator.Send(SalaryCommand));

        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(DeleteSalaryCommand SalaryCommand)
        {
            return Ok(await _mediator.Send(SalaryCommand));

        }
    }
}
