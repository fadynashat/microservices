using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADY.Services.Employee.API.Application.Queries
{

    public class EmployeeView
    {
        public Address Address { get;  set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Submitted { get; set; }
        public string ImagePath { get; set; }

    }


}
