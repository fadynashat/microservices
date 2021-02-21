using FADY.Services.Employee.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate
{
    public class Address : ValueObject
    {

        public String Street { get;  set; }
        public String City { get;  set; }
        public String Country { get;  set; }

        public Address()
        { }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return Country;
        }
    }
}
