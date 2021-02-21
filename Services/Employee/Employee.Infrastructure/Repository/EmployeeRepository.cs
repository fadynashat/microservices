using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using FADY.Services.Employee.Dmoain.SeedWork;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FADY.Services.Employee.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {


        private readonly EmployeeContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Dmoain.AggregatesModel.EmployeeAggregate.Employe Add(Dmoain.AggregatesModel.EmployeeAggregate.Employe employee)
        {
            return _context.Employees.Add(employee).Entity;
        }

        public async Task<Dmoain.AggregatesModel.EmployeeAggregate.Employe> GetAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
              
                await _context.Entry(employee)
                    .Reference(i => i.Address).LoadAsync();
             
            }

            return employee;
        }

        public void Update(Dmoain.AggregatesModel.EmployeeAggregate.Employe employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int employeeId)
        {
            var employee =  _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Entry(employee).State = EntityState.Deleted;
            }
        }
    }
}
