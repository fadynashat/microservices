using FADY.WebMVC.Services;
using FADY.WebMVC.ViewModels;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FADY.WebMVC.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
    public class EmployeeController : Controller
    {
        private IEmployeeService _empSvc;
      
        private readonly IIdentityParser<ApplicationUser> _appUserParser;
        public EmployeeController(IEmployeeService empSvc,IIdentityParser<ApplicationUser> appUserParser)
        {
            _appUserParser = appUserParser;
            _empSvc = empSvc;
         
        }
        public async Task<IActionResult> Index()
        {
            //return TempData of user and access_token as json 
            ViewBag.tokenjson = null;
            ViewBag.userjson = new JavaScriptSerializer().Serialize(HttpContext.User).ToString();

            return View();
        }
    }
}
