using System.Collections.Generic;

namespace FADY.GatewayAggregator.Config
{

    public class UrlsConfig
    {
        public class EmployeeOperations
        {
            public static string GetEmployeeById(int id) => $"/api/v1/Employee/{id}";

            public static string GetSalaryById(int id) => $"/api/v1/Employee/{id}";
        }

    }

}
