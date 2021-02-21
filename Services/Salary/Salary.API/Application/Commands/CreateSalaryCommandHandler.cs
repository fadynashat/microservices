using MediatR;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class CreateSalaryCommandHandler : IRequestHandler<CreateSalaryPermanentCommand, bool>
    {
        private readonly ISalaryRepository _Repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        public CreateSalaryCommandHandler(IMediator mediator, ISalaryRepository Repository)
        {
            _mediator = mediator;
            _Repository = Repository;
        }

        public async Task<bool> Handle(CreateSalaryPermanentCommand request, CancellationToken cancellationToken)
        {
            var salary = new Dmoain.AggregatesModel.SalaryAggregate.salary(request.EmpId,request.Salary );
            _Repository.Add(salary);
            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
