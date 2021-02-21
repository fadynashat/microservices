using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System.Data.SqlClient;
using Dapper;

namespace FADY.Services.Employee.API.Application.Queries
{
    public class EmployeeQueries : IEmployeeQueries

    {
        private string _connectionString = string.Empty;



        public EmployeeQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));

        }
        public async Task<IEnumerable<EmployeeView>> GetAllEmployeeAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.QueryAsync<EmployeeView>("SELECT TOP (10) *  FROM [EmployeeDb].[dbo].[Employees]");
                return await (res);

            }
        }

        public async Task<EmployeeView> GetEmployeeAsync(int id)
        {
            dynamic result ;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                 result = await connection.QueryAsync<dynamic>
                    (@"Select * from [EmployeeDb].[dbo].[Employees] where Id = @id"

                        , new { id }
                        );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

              
            }
            return MapEmployeeData(result);
        }

        private EmployeeView MapEmployeeData(dynamic result)
        {
            var Employee = new EmployeeView
            {
               Address =new  Address(result[0].Address_Street,result[0].Address_City, result[0].Address_Country),
                Name = result[0].Name,
          Phone = result[0].Phone,
          Submitted = result[0].Submitted,
          ImagePath = result[0].ImagePath

            };

            return Employee;
        }

    }
}
