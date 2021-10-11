using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Controllers;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.Tests.WebAPI.XUnitTest.Mock;
using System;
using System.Collections.Generic;
using Xunit;

namespace SEDCWebApplication.Tests.WebAPI.XUnitTest
{
    public class CustomerControllerUnitTest
    {
        CustomerController _controller;
        ICustomerService _service;
        public CustomerControllerUnitTest()
        {
            _service = new CustomerServiceMock();
            _controller = new CustomerController(_service, null, null);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            //Act
            var okResult = _controller.Get().Result as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<CustomerDTO>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Theory]
        [InlineData(1)]
        public void GetById_WhenCalled_ReturnsOkResult(int id)
        {
            //Act
            var okResult = _controller.GetById(id);

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData(1)]
        public void GetById_WhenCalled_ReturnsRightItem(int id)
        {
            //Act
            var okResult = _controller.GetById(id).Result as OkObjectResult;

            //Assert
            var item = Assert.IsType<CustomerDTO>(okResult.Value);
            Assert.Equal("Maja", item.Name);
        }
    }
}
