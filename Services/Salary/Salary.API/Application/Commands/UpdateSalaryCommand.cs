using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class UpdateSalaryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public double salary { get; set; }

        public UpdateSalaryCommand()
        {

        }
        public UpdateSalaryCommand(int _empId , double _salary)
        {
            EmpId = _empId;
            salary = _salary;
        }
    }
}
