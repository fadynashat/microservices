
using FADY.Services.Employee.API.Infrastructure.Services;

using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace UnitTest.Employee.Application
{
    using FADY.Services.Employee.API.Application.Commands;
    using FADY.Services.Employee.API.Application.IntegrationEvents;
    using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;

    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using Xunit;

    public class EmployeeParmenentCommandHandlerTest
    {
        private readonly Mock<IEmployeeRepository> _orderRepositoryMock;
        private readonly Mock<IIdentityService> _identityServiceMock;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IEmployeeIntegrationEventService> _EmployeeIntegrationEventService;

        public EmployeeParmenentCommandHandlerTest()
        {

            _orderRepositoryMock = new Mock<IEmployeeRepository>();
            _identityServiceMock = new Mock<IIdentityService>();
            _EmployeeIntegrationEventService = new Mock<IEmployeeIntegrationEventService>();
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Handle_return_false_if_Employee_created()
        {
       
        }

        [Fact]
        public void Handle_throws_exception_when_no_EmployeeId()
        {
           
        }

 
        private Employe FakeEmployee()
        {
            return new Employe(1, "fakeName", new Address("street", "city", "country"), "01208844875");
        }

        private CreateEmployeePermanentCommand FakeEmployeeParmenentCommand(Dictionary<string, object> args = null)
        {
            return new CreateEmployeePermanentCommand(1,new Address("street", "city", "country"), "fakeName", "01208844875");
               
        }
    }
}
