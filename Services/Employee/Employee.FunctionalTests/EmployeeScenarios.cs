using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Employee.FunctionalTests
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
        public async Task Get_employee_by_id_and_response_bad_request_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.EmployeesById(-1));

                response.EnsureSuccessStatusCode();
            }
        }
        [Fact]
        public async Task Post_employee_and_response_Not_found_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.EmployeesById(-1));

                response.EnsureSuccessStatusCode();
            }
        }
        [Fact]
        public async Task Post_employee_and_response_bad_request_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildbadEmployee(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateIdempotentClient()
                    .PostAsync(Post.Employees, content);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }
        [Fact]
        public async Task Post_employee_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildgoodEmployee(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateIdempotentClient()
                    .PutAsync(Post.Employees, content);

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
            var emp = new Employe()
            {
                //fill correct data
            };
            return JsonConvert.SerializeObject(emp);
        }
    }
}
