using MediatR;
using Microsoft.AspNetCore.Mvc;

using FADY.Services.Employee.API.Controllers;

using Microsoft.Extensions.Logging;
using Moq;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FADY.Services.Employee.API.Application.Queries;
using FADY.Services.Employee.API.Infrastructure.Services;

namespace UnitTest.Employee.Application
{
    public class EmployeeWebApiTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IEmployeeQueries> _employeeQueriesMock;
        private readonly Mock<IIdentityService> _identityServiceMock;
        private readonly Mock<ILogger<EmployeeController>> _loggerMock;

        public EmployeeWebApiTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeQueriesMock = new Mock<IEmployeeQueries>();
            _identityServiceMock = new Mock<IIdentityService>();
            _loggerMock = new Mock<ILogger<EmployeeController>>();
        }

 
        [Fact]
        public async Task Get_Employee_success()
        {
            //Arrange
            var fakeDynamicResult = Enumerable.Empty<EmployeeView>();

            _identityServiceMock.Setup(x => x.GetUserIdentity())
                .Returns(Guid.NewGuid().ToString());

             _employeeQueriesMock.Setup(x => x.GetAllEmployeeAsync());

            //Act
            var employeeController = new EmployeeController(_mediatorMock.Object, _employeeQueriesMock.Object, _identityServiceMock.Object, _loggerMock.Object);
            var actionResult= await employeeController.Get();

            //Assert
            Assert.Equal((actionResult as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

     

   
    }
}
