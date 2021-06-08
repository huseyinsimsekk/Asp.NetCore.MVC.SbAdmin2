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
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetData()
        {
            // Get request in chart-demo.js and send data in here. 
            int[] data = new int[] { 0, 10000, 5000, 15000, 10000, 8000, 15000, 20000, 10000, 15000, 25000, 17500 };
            return Json(data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
