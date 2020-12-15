using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SbAdmin2.Core.Contracts;
using SbAdmin2.Web.Controllers;
using SbAdminCore.Models;

namespace SbAdminCore.Controllers
{
    public class HomeController : MainController
    {
        private readonly IEmployeeService _employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _employeeService.GetAllAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public JsonResult GetData()
        {
            // Get request in site.js and send data in here. 
            int[] data = new int[] { 0, 10000, 5000, 15000, 10000, 8000, 15000, 20000, 10000, 15000, 25000, 17500 };
            return Json(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
