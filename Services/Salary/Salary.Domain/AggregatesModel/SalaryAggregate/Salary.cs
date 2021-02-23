using FADY.Services.Salary.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate
{
    public class salary : Entity, IAggregateRoot
    {
  
        public int EmpId { get;  set; }
        public double Sal { get;  set; }


        public salary()
        {

        }

        public salary(int _EmpId, double _Sal)
        {
            EmpId = _EmpId;
            Sal = _Sal;
        }



        public void Updatesalary(double salary)
        {
            Sal = salary;
        }
    }
}
