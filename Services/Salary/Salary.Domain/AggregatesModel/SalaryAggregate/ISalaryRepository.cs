using FADY.Services.Salary.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate
{
    public interface ISalaryRepository : IRepository<salary>
    {
        salary Add(salary salary);

        void Update(salary salary);

        Task<salary> GetAsync(int salaryId);

        void Delete(int id);
    }
}
