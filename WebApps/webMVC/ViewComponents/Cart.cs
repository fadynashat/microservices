using Microsoft.AspNetCore.Mvc;
using FADY.WebMVC.Services;
using FADY.WebMVC.ViewModels;

using System.Threading.Tasks;

namespace FADY.WebMVC.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly IEmployeeService _cartSvc;

        public Cart(IEmployeeService cartSvc) => _cartSvc = cartSvc;

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new Employee();
            try
            {
               
                return View(vm);
            }
            catch
            {
                ViewBag.IsEmployeeInoperative = true;
            }

            return View(vm);
        }
    
    }
}
