using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Commands
{
    public class CreateEmployeePermanentCommand : IRequest<bool>
    {
        public int EmpId { get; set; }
        public Address Address { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }


        public CreateEmployeePermanentCommand()
        {

        }
        public CreateEmployeePermanentCommand(int _empId)
        {
            EmpId = _empId;
        }
        public CreateEmployeePermanentCommand(int _empId 
           , Address _address
            , string _name
            , string _phone
           )
        {
            EmpId = _empId;
            Address = _address;
            Name = _name;
            Phone = _name;
          
          

        }
    }
}
