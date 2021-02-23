using FADY.GatewayAggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.GatewayAggregator.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeSalaryData> GetEmployeeSalaryData(EmployeeData EmployeeData);
    }
}
