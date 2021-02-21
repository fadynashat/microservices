using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Commands
{
    public class DeleteEmployeePermanentCommand : IRequest<bool>
    {
        public int id { get; set; }
        public DeleteEmployeePermanentCommand()
        {

        }
        public DeleteEmployeePermanentCommand(int Id)
        {
            id = Id;
        }
    }
}
