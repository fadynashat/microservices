using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class DeleteSalaryCommand : IRequest<bool>
    {
        public int id { get; set; }
        public DeleteSalaryCommand()
        {

        }
        public DeleteSalaryCommand(int Id)
        {
            id = Id;
        }
    }
}
