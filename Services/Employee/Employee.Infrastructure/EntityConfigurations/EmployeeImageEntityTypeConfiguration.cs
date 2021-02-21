using FADY.Services.Employee.Dmoain.SeedWork;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FADY.Services.Employee.Infrastructure.EntityConfigurations
{
   public class EmployeeImageEntityTypeConfiguration: IEntityTypeConfiguration<Employee.Dmoain.AggregatesModel.EmployeeAggregate.Employe>
    {
        public void Configure(EntityTypeBuilder<Dmoain.AggregatesModel.EmployeeAggregate.Employe> EmpConfiguration)
        {



            EmpConfiguration.Property(o => o.ImagePath);

        }


    }
}
