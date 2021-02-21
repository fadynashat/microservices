using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Salary.API.Application.Commands
{
    public class CreateSalaryPermanentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public double Salary { get; set; }



        public CreateSalaryPermanentCommand()
        {

        }
        public CreateSalaryPermanentCommand(int empId, double salary)
         
        {
            EmpId = empId;
            Salary = salary;
        }
    }
}
