using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SbAdmin2.Web.Controllers
{
    public class SettingsController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveThemeColor(string themeColor)
        {
            ViewBag.ThemeColor = themeColor ?? "bg-gradient-primary";
            return Json(new { Msg = "success" });
        }
    }
}
