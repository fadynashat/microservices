using FADY.Services.Salary.Dmoain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADY.Services.Salary.Domain.AggregatesModel.AttendanceAggregate
{
    public interface IAttandceRepository:IRepository<Attendance>
    {
        Attendance Add(Attendance attendance);

        void Update(Attendance attendance);

        Task<Attendance> GetAsync(int attendanceId);

        void Delete(int id);
    }
}
