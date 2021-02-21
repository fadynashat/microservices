using FluentValidation;
using FADY.Services.Employee.API.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Validations
{
    public class CreateEmployeePermanentValidator : AbstractValidator<CreateEmployeePermanentCommand>
    {
        public CreateEmployeePermanentValidator()
        {
            RuleFor(command => command.Name).MinimumLength(6).WithMessage("The Employee Name Must be greater than 6");
        }
    }
}
