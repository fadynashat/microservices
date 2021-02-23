using FADY.GatewayAggregator.Config;
using FADY.GatewayAggregator.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcEmployee;
using static GrpcEmployee.EmployeeGrpc;

namespace FADY.GatewayAggregator.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeGrpcClient _EmployeeGrpcClient;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(EmployeeGrpcClient EmployeeGrpcClient, ILogger<EmployeeService> logger)
        {
            _EmployeeGrpcClient = EmployeeGrpcClient;
            _logger = logger;
        }

     
        public async Task<Models.EmployeeSalaryData> GetEmployeeSalaryData(EmployeeData employeeData)
        {
            _logger.LogDebug(" grpc client created, EmployeeData={@EmployeeData}", employeeData);

            var command = MapToEmployeeSalaryCommand(employeeData);
            var response =  _EmployeeGrpcClient.CreateEmployeeSalaryData(command);
            _logger.LogDebug(" grpc response: {@response}", response);
            return MapToResponse(response);
        } 


        private CreateEmployeeSalaryCommand MapToEmployeeSalaryCommand(EmployeeData employeeData)
        {
            var command = new CreateEmployeeSalaryCommand
            {
                EmpId = employeeData.Emp_id
              
            };

     

            return command;
        }

        private Models.EmployeeSalaryData MapToResponse(GrpcEmployee.EmployeeSalaryData employeesalary)
        {
            var data = new Models.EmployeeSalaryData
            {
                   

             };
            return data;
        }
    }
}
