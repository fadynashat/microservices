using FADY.Services.Employee.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate
{
    public class Employe : Entity, IAggregateRoot
    {
        public int EmpId { get; set; }
        public Address Address { get; private set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        private Enum Postion { get; set; }

        private Enum Level { get; set; }

        public int Submitted { get; set; }

        public string ImagePath { get; set; }

        public Employe()
        {

        }
        public Employe(int _EmpId,string _Name, Address _Address, string _Phone)
        {
            EmpId = _EmpId;
            Name = _Name;
            Phone = _Phone;
            Address = _Address;
            Submitted = 0;
        }


    }
}
