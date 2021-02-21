using Microsoft.AspNetCore.Mvc;
using FADY.WebMVC.Services;
using FADY.WebMVC.ViewModels;
using System;
using System.Threading.Tasks;

namespace FADY.WebMVC.ViewComponents
{
    public class CartList : ViewComponent
    {
        private readonly IEmployeeService _cartSvc;

        public CartList(IEmployeeService cartSvc) => _cartSvc = cartSvc;

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new Employee();
            try
            {
                vm = await GetItemsAsync(user);
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.EmployeeInoperativeMsg = $"Employee Service is inoperative, please try later on. ({ex.GetType().Name} - {ex.Message}))";
            }

            return View(vm);
        }

        private Task<Employee> GetItemsAsync(ApplicationUser user) => _cartSvc.GetEmployee(user);
    }
}
