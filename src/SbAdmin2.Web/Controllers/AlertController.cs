using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SbAdmin2.Core.Contracts;

namespace SbAdmin2.Web.Controllers
{
    public class AlertController : MainController
    {
        private IAlertService _alertService;
        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;
        }
        public IActionResult Index()
        {
            var alerts = _alertService.GetMany(m => !m.IsDeleted);
            return View(alerts);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var alert = await _alertService.GetByIdAsync(id);
            return View(alert);
        }
    }
}
