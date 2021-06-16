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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(model);
                return RedirectToAction("Index", "Employee");
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", "Employee");
            var model = await _employeeService.GetByIdAsync(id.Value);
            if (model is null) return NotFound();

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(model);
            }
            return View(model);
        }
        public JsonResult Delete(int id)
        {
            var employee = _employeeService.GetByIdAsync(id).Result;
            _employeeService.Delete(employee);
            // will edit as soon as possible time
            return Json("sucess");
        }
    }
}
