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
                //var response = await server.CreateClient()
                //    .GetAsync(Get.);

                //response.EnsureSuccessStatusCode();
            }
        }

        string BuildEmployee()
        {
            var emp = new Employe()
            {
           
            };
            return JsonConvert.SerializeObject(emp);
        }
    }
}
