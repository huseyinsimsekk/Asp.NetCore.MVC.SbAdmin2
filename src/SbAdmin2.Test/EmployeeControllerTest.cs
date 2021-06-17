using Microsoft.AspNetCore.Mvc;
using Moq;
using SbAdmin2.Core.Contracts;
using SbAdmin2.Core.Models;
using SbAdmin2.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SbAdmin2.Test
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _employeeMock;
        private readonly EmployeeController _employeeController;
        private readonly List<Employee> _employees;
        public EmployeeControllerTest()
        {
            _employeeMock = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeMock.Object);
            _employees = new List<Employee>() {
                new Employee(){Id=1, BeginDate= DateTime.Now, Gender=1, IsDeleted=false, Name="Joe", LastName="Doe", Salary=4000.5m },
                new Employee(){Id=2, BeginDate= DateTime.Now, Gender=1, IsDeleted=false, Name="Huseyin", LastName="Simsek", Salary=4500 },
            };
        }
        [Fact]
        public async void Index_ShouldReturnEmployees_WhenExecute()
        {
            _employeeMock.Setup(m => m.GetAllAsync()).ReturnsAsync(_employees);
            var result = await _employeeController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var expectedEmployees = Assert.IsAssignableFrom<IEnumerable<Employee>>(viewResult.Model);
            Assert.Equal<int>(2, expectedEmployees.Count());
        }
        [Fact]
        public void Add_ShouldReturnEmployee_WhenExecute()
        {
            var result = _employeeController.Add();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Add_ShouldReturnView_WhenInvalidModelState()
        {
            _employeeController.ModelState.AddModelError("Name", "Name is required!");
            var result = await _employeeController.Add(_employees.First());
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<Employee>(viewResult.Model);
        }

        [Fact]
        public async void Add_ShouldRedirectToIndex_WhenValidModelState()
        {
            var result = await _employeeController.Add(_employees.First());
            var redirectAction = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectAction.ActionName);
        }

        [Fact]
        public async void Add_ShouldExecute_WhenValidModelState()
        {
            Employee employee = null;
            _employeeMock.Setup(m => m.AddAsync(It.IsAny<Employee>())).Callback<Employee>(x => employee = x);
            // Herhangi verilen bir Employee nesnesi yakalamak için callback methodunu çalıştırıyoruz
            var result = await _employeeController.Add(_employees.First());

            _employeeMock.Verify(v => v.AddAsync(It.IsAny<Employee>()), Times.Once);
            Assert.Equal(_employees.First().Id, employee.Id);
        }

        [Fact]
        public async void Update_ShouldRedirectToIndex_WhenIdIsNull()
        {
            int? id = null;
            var result = await _employeeController.Update(id);
            var redirectToResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToResult.ActionName);
            Assert.Equal("Employee", redirectToResult.ControllerName);
        }

        [Theory]
        [InlineData(1212)]
        public async void Update_ShouldReturnNotFound_WhenIdIsNotFound(int id)
        {
            Employee employee = null;
            _employeeMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employee);
            var result = await _employeeController.Update(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public async void Update_ShouldReturnView_WhenIdIsFound(int id)
        {
            var employee = _employees.First(m => m.Id == id);
            _employeeMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(employee);
            var result = await _employeeController.Update(id);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Employee>(viewResult.Model);
            var model = Assert.IsAssignableFrom<Employee>(viewResult.Model);
            Assert.Equal(employee.Id, model.Id);
        }
        [Fact]
        public void Update_ShouldReturnView_WhenModelStateIsNotValid()
        {
            Employee employee = null;
            _employeeController.ModelState.AddModelError("Name", "Is Required");
            var result = _employeeController.Update(employee);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Update_ShouldRedirectToAction_WhenModelStateIsValid()
        {
            Employee employee = _employees.First();
            var result = _employeeController.Update(employee);
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("Employee", redirect.ControllerName);
        } 
        [Fact]
        public void Update_ShouldExecute_WhenModelStateIsValid()
        {
            Employee employee = _employees.First(x=>x.Id==1);
            _employeeMock.Setup(x => x.Update(employee));
            var result = _employeeController.Update(employee);
            _employeeMock.Verify(x => x.Update(It.IsAny<Employee>()), Times.Once);
        }
    }
}
