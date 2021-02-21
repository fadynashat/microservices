using System;
using System.Collections.Generic;
using System.Text;
using FADY.Services.Salary.Dmoain.SeedWork;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FADY.Services.Salary.Infrastructure;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using System.Threading;

namespace FADY.Services.Salary.Infrastructure.Repository
{
    public class SalaryRepository : ISalaryRepository
    {


        private readonly SalaryContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public SalaryRepository(SalaryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Salary.Dmoain.AggregatesModel.SalaryAggregate.salary Add(Salary.Dmoain.AggregatesModel.SalaryAggregate.salary Salary)
        {
            return _context.Salary.Add(Salary).Entity;
        }

        public async Task<Salary.Dmoain.AggregatesModel.SalaryAggregate.salary> GetAsync(int SalaryId)
        {
            var Salary = await _context.Salary.FindAsync(SalaryId);


            return Salary;
        }

        public void Update(Salary.Dmoain.AggregatesModel.SalaryAggregate.salary Salary)
        {
            _context.Entry(Salary).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var Salary = _context.Salary.Find(id);
            _context.Salary.Remove(Salary);
        }

    }
}
