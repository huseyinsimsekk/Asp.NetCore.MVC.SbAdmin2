using Microsoft.AspNetCore.Mvc;
using Moq;
using SbAdmin2.Core.Contracts;
using SbAdmin2.Core.Models;
using SbAdmin2.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SbAdmin2.Test
{
    public class AlertControllerTest
    {
        private readonly Mock<IAlertService> _alertMock;
        private readonly AlertController _alertController;
        private readonly List<Alert> _alerts;
        public AlertControllerTest()
        {
            _alertMock = new Mock<IAlertService>();
            _alertController = new AlertController(_alertMock.Object);
            _alerts = new List<Alert>() {
                new Alert(){ Id=1, Description="Description1", Title="Title1",IsDeleted= false},
                new Alert(){ Id=2, Description="Description2", Title="Title2",IsDeleted= true},
                new Alert(){ Id=3, Description="Description3", Title="Title3",IsDeleted= false}
            };
        }
        [Fact]
        public void Index_ShouldReturnView_WhenExecute()
        {
            var result = _alertController.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ShouldReturnAlertList_WhenExecute()
        {
            _alertMock.Setup(m => m.GetMany(It.IsAny<Func<Alert, bool>>())).Returns(_alerts);
            var result = _alertController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);

            var alertList = Assert.IsAssignableFrom<IEnumerable<Alert>>(viewResult.Model);

            Assert.Equal<int>(3, alertList.Count());
        }

        [Fact]
        public async Task Detail_ShouldReturnView_WhenExecute()
        {
            var result = await _alertController.Detail(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Detail_ShouldReturnNotFound_WhenIdIsNotFound()
        {
            var result = await _alertController.Detail(1);
            Assert.IsType<ViewResult>(result);
        }
    }
}
