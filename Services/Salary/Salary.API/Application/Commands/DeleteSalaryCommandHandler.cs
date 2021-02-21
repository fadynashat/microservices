using MediatR;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class DeleteSalaryCommandHandler : IRequestHandler<DeleteSalaryCommand, bool>
    {
        private readonly ISalaryRepository _Repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        public DeleteSalaryCommandHandler(IMediator mediator, ISalaryRepository Repository)
        {
            _mediator = mediator;
            _Repository = Repository;
        }

        public async Task<bool> Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
        {

            _Repository.Delete(request.id);

            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
