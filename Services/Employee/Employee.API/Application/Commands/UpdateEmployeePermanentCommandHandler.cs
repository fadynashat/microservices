using MediatR;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Commands
{
    public class UpdateEmployeePermanentCommandHandler : IRequestHandler<UpdateEmployeePermanentCommand, bool>
    {
        private readonly IEmployeeRepository _Repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        public UpdateEmployeePermanentCommandHandler(IMediator mediator, IEmployeeRepository Repository)
        {
            _mediator = mediator;
            _Repository = Repository;
        }

        public async Task<bool> Handle(UpdateEmployeePermanentCommand request, CancellationToken cancellationToken)
        {
            var Employee = new Dmoain.AggregatesModel.EmployeeAggregate.Employe(request.EmpId,
                    request.Name,
                  request.Address,
                  request.Phone
                  );
            _Repository.Update(Employee);

            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
