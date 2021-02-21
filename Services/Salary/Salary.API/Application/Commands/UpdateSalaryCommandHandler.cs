using MediatR;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class UpdateSalaryCommandHandler : IRequestHandler<UpdateSalaryCommand, bool>
    {
        private readonly ISalaryRepository _Repository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        public UpdateSalaryCommandHandler(IMediator mediator, ISalaryRepository Repository)
        {
            _mediator = mediator;
            _Repository = Repository;
        }

        public async Task<bool> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
        {
            var SalaryInDb = await _Repository.GetAsync(request.Id);
            SalaryInDb.Updatesalary(request.salary);

            _Repository.Update(SalaryInDb);

            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
