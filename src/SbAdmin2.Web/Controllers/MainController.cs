using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SbAdmin2.Web.Controllers
{
    public abstract class MainController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Assign default and change when user select another color in settings. !!! Look at this
            if (ViewBag.ThemeColor == null)
            {
                ViewBag.ThemeColor = "bg-gradient-primary";
            }
        }
    }
}
