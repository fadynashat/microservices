namespace FADY.Services.Employee.API.Infrastructure
{

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;

    using FADY.Services.Employee.Dmoain.SeedWork;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Employee.Infrastructure;
    using Polly;
    using Polly.Retry;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using FADY.Employee.API;

    public class EmployeeContextSeed
    {
        public async Task SeedAsync(EmployeeContext context, IWebHostEnvironment env, IOptions<EmployeeSettings> settings, ILogger<EmployeeContextSeed> logger)
        {
        }

    

        private string[] GetHeaders(string[] requiredHeaders, string csvfile)
        {
            string[] csvheaders = File.ReadLines(csvfile).First().ToLowerInvariant().Split(',');

            if (csvheaders.Count() != requiredHeaders.Count())
            {
                throw new Exception($"requiredHeader count '{ requiredHeaders.Count()}' is different then read header '{csvheaders.Count()}'");
            }

            foreach (var requiredHeader in requiredHeaders)
            {
                if (!csvheaders.Contains(requiredHeader))
                {
                    throw new Exception($"does not contain required header '{requiredHeader}'");
                }
            }

            return csvheaders;
        }


        private AsyncRetryPolicy CreatePolicy(ILogger<EmployeeContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
    }
}
