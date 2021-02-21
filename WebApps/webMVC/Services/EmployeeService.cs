
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FADY.WebMVC.Infrastructure;

using FADY.WebMVC;
using FADY.WebMVC.ViewModels;

namespace FADY.WebMVC.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly ILogger<EmployeeService> _logger;
        private readonly string _employeeByPassUrl;
        private readonly string _employeeUrl;

        public EmployeeService(HttpClient httpClient, IOptions<AppSettings> settings, ILogger<EmployeeService> logger)
        {
            _apiClient = httpClient;
            _settings = settings;
            _logger = logger;

           _employeeByPassUrl = $"{_settings.Value.EmployeeUrl}/api/Employee";
            _employeeUrl = $"{_settings.Value.EmployeeUrl}/api/";
        }

        public async Task<Employee> GetEmployee(ApplicationUser user)
        {
            var uri = API.Employee.GetEmployee(_employeeByPassUrl, user.Id);
            _logger.LogDebug("[GetEmployee] -> Calling {Uri} to get the Employee", uri);
            var response = await _apiClient.GetAsync(uri);
            _logger.LogDebug("[GeEmployee] -> response code {StatusCode}", response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(responseString) ?
                new Employee() { empId = user.Id } :
                JsonConvert.DeserializeObject<Employee>(responseString);
        }

    }
}
