using MediatR;
using FADY.Services.Salary.Domain.AggregatesModel.AttendanceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class CreateAttandanceCommandHandler : IRequestHandler<CreateAttandanceCommand, bool>
    {
        private readonly IAttandceRepository _Repository;
        private readonly IMediator _mediator;
        public CreateAttandanceCommandHandler(IMediator mediator, IAttandceRepository Repository)
        {
            _mediator = mediator;
            _Repository = Repository;
        }

        public async Task<bool> Handle(CreateAttandanceCommand request, CancellationToken cancellationToken)
        {
            var attandance = new Attendance(request.Days);
            _Repository.Add(attandance);

            return await _Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

    }
}
