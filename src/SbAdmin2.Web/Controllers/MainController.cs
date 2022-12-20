using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SbAdmin2.Web.Controllers
{
    public abstract class MainController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.ThemeColor = HttpContext.Session.GetString("ThemeColor") ?? "primary";
        }
    }
}
