using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbAdmin2.Web.Controllers
{
    public class ErrorController : MainController
    {
        public IActionResult Index()
        {
            var exceptionData = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // TODO: log exception data
            return View();
        }
    }
}
