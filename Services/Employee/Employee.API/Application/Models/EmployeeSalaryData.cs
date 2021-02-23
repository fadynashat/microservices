using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using MediatR;
namespace FADY.Services.Employee.API.Application.Models
{
    public class EmployeeSalaryData
    {
       public EmployeDto emp { get; set; }
        public salaryDto salary { get; set; }

    }
}


public class salaryDto
{
    public int EmpId { get; set; }
    public double Sal { get; set; }
    public salaryDto(int _empId, double _sal)
    {
        EmpId = _empId;
        Sal = _sal;
    }
}

public class EmployeDto
{
    public int EmpId { get; set; }
    public Address Address { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public EmployeDto(int _empId)
    {
        EmpId = _empId;
    }
}