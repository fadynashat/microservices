using FADY.Services.Employee.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employe>
    {
        Employe Add(Employe mployee);

        void Update(Employe mployee);

        Task<Employe> GetAsync(int employeeId);

        void Delete(int employeeId);
    }
}
