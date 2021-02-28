using FADY.Services.Employee.API.Application.Commands;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace FADY.Services.Employee.FunctionalTests
{
    public class EmployeeScenarios
        : EmployeeScenarioBase
    {
        [Fact]
        public async Task Get_get_all_employee_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.Employees);

                response.EnsureSuccessStatusCode();
            }
        }
        [Fact]
        public async Task Get_employee_by_id_and_response_not_found()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.EmployeesById(-1));

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_employee_by_id_and_response_ok_request_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.EmployeesById(1));

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        [Fact]
        public async Task Post_employee_and_response_bad_request_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildbadEmployee(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateIdempotentClient()
                    .PostAsync(PostAsync.Employees, content);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
        [Fact]
        public async Task Post_employee_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var str = BuildgoodEmployee();
                var content = new StringContent(BuildgoodEmployee(), UTF8Encoding.UTF8, "application/json");
             
                var response = await server.CreateIdempotentClient()
                    .PostAsync(PostAsync.Employees, content);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        string BuildbadEmployee()
        {
            var emp = new Employe()
            {
           //fill uncorrect data
            };
            return JsonConvert.SerializeObject(emp);
        }
        string BuildgoodEmployee()
        {
            var _random = new Random();
            var identity = _random.Next(1, 10000000);

            var name = "fadynashat";
            var address = new Address("el-shorta street", "assuit", "egypt");
 
            var goodemp = new CreateEmployeePermanentCommand(identity,  address, name, "01208844875");
            return JsonConvert.SerializeObject(goodemp);
        }
    }
}
