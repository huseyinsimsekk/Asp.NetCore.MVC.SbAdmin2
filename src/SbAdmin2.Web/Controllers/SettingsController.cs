using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SbAdmin2.Web.Controllers
{
    public class SettingsController : MainController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public SettingsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveThemeColor(string themeColor)
        {
            //ViewBag.ThemeColor = themeColor ?? "bg-gradient-primary";
            _session.SetString("ThemeColor", themeColor);
            return Json(new { Msg = "success" });
        }
    }
}
