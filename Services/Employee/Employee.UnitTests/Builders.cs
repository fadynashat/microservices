
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;

namespace UnitTest.Employee
{
    public class AddressBuilder
    {
        public Address Build()
        {
            return new Address("street", "city",  "country");
        }
    }

    public class EmployeeBuilder
    {
        private readonly Employe emp;

        public EmployeeBuilder(Address address)
        {
            emp = new Employe(100, "fady", address, "012088444875");
              
        }

        public EmployeeBuilder AddOne()
        {
          
            return this;
        }

        public Employe Build()
        {
            return emp;
        }
    }
}
