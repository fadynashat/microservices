using FADY.WebMVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using FADY.WebMVC.Services.ModelDTOs;

namespace FADY.WebMVC.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(ApplicationUser user);
       
       
        
    }
}
