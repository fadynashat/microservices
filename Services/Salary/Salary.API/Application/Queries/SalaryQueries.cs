using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using System.Data.SqlClient;
using Dapper;

namespace FADY.Services.Salary.API.Application.Queries
{
    public class SalaryQueries : ISalaryQueries

    {
        private string _connectionString = string.Empty;



        public SalaryQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));

        }
        public async Task<IEnumerable<SalaryView>> GetAllSalaryAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.QueryAsync<SalaryView>("SELECT TOP (10) *  FROM [SalaryDb].[dbo].[Salary]");
                return await (res);

            }
        }

        public async Task<SalaryView> GetSalaryAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>
                    (@"Select * from [SalaryDb].[dbo].[Salary] where Id = @id"

                        , new { id }
                        );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrderItems(result);
            }
        }

        private SalaryView MapOrderItems(dynamic result)
        {
            var Salary = new SalaryView
            {
                Sal = result[0].Sal,
                EmpId = result[0].EmpId
            };

            return Salary;
        }

    }
}
