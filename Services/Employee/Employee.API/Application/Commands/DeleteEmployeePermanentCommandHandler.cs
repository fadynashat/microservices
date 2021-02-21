using MediatR;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Commands
{
    public class DeleteEmployeePermanentCommandHandler : IRequestHandler<DeleteEmployeePermanentCommand, bool>
    {
        private readonly IEmployeeRepository _Repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        public DeleteEmployeePermanentCommandHandler(IMediator mediator, IEmployeeRepository Repository)
        {
            _mediator = mediator;
            _Repository = Repository;
        }

        public async Task<bool> Handle(DeleteEmployeePermanentCommand request, CancellationToken cancellationToken)
        {

            _Repository.Delete(request.id);

            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
