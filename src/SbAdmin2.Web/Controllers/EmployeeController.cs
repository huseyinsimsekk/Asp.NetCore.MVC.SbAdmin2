using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SbAdmin2.Core.Contracts;
using SbAdmin2.Core.Models;

namespace SbAdmin2.Web.Controllers
{
    public class EmployeeController : MainController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();
            return View(employees);
        }
        public IActionResult Add()
        {
            var model = new Employee();
            model.BeginDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(model);
            }
            return View(model);
        }
    }
}
