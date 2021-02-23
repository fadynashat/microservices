using FADY.GatewayAggregator.Config;
using FADY.GatewayAggregator.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FADY.GatewayAggregator.Services
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _apiClient;
        private readonly ILogger<EmployeeApiClient> _logger;
        private readonly UrlsConfig _urls;

        public EmployeeApiClient(HttpClient httpClient, ILogger<EmployeeApiClient> logger, IOptions<UrlsConfig> config)
        {
            _apiClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }

      
        public async Task<EmployeeSalaryData> GetEmployeeSalaryData(EmployeeData emp)
        {
            var url = UrlsConfig.EmployeeOperations.GetEmployeeById(emp.Emp_id);
            var content = new StringContent(JsonConvert.SerializeObject(emp), System.Text.Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EmployeeSalaryData>(ordersDraftResponse);
        }
    }
}
