using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Queries
{
   public interface IEmployeeQueries
   {
            Task<EmployeeView> GetEmployeeAsync(int id);

            Task<IEnumerable<EmployeeView>> GetAllEmployeeAsync();
   }
    
}
