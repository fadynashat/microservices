using Grpc.Core;
using MediatR;
using FADY.BuildingBlocks.EventBus.Extensions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FADY.Services.Employee.API.Application.Commands;
using FADY.Services.Employee.API.Application.Models;

namespace GrpcEmployee
{
    public class EmployeeService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IMediator mediator, ILogger<EmployeeService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public  async Task<EmployeeSalaryData> CreateEmployeeSalaryData(CreateEmployeeSalaryCommand createEmployeeSalaryCommand, ServerCallContext context)
        {               
            _logger.LogInformation("Begin grpc call from method {Method} for Employee get create employee with salary {CreateEmployeeSalaryCommand}", context.Method, createEmployeeSalaryCommand);
            _logger.LogTrace(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                createEmployeeSalaryCommand.GetGenericTypeName(),
                nameof(createEmployeeSalaryCommand.EmpId),
                createEmployeeSalaryCommand.EmpId,
                createEmployeeSalaryCommand);

           // var command = new CreateEmployeeSalaryCommand( createEmployeeSalaryCommand.EmpId);


            //var data; //=// await _mediator.Send(command);

            //if (data != null)
            //{
            //    context.Status = new Status(StatusCode.OK, $" Employee get net salary  {createEmployeeSalaryCommand}");

            //    return this.MapResponse(data);
            //}
            //else
            {
                context.Status = new Status(StatusCode.NotFound, $" Employee get net salary {createEmployeeSalaryCommand} do not exist");
            }

            return new EmployeeSalaryData();
        }

        public EmployeeSalaryData MapResponse(EmployeeSalaryData empsalary)
        {
            var result = new EmployeeSalaryData()
            {
            
        };
            return result;
        }

      
    }
}
