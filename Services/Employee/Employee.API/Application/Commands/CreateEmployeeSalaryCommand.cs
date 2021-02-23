using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADY.Services.Employee.API.Application.Models;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using MediatR;

namespace FADY.Services.Employee.API.Application.Commands
{
    public class CreateEmployeeSalaryCommand : IRequest<EmployeeSalaryData>
    {
        public int EmpId { get; set; }
        public double salary { get; set; }

       

        public CreateEmployeeSalaryCommand()
        {

        }
        public CreateEmployeeSalaryCommand(int _empId)
        {
            EmpId = _empId;
        }
        public CreateEmployeeSalaryCommand(int _empId , double _salary)
        {
            EmpId = _empId;
            salary = _salary;

        }
    }
}
