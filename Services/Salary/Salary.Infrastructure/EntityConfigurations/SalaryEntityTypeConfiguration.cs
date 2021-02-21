using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FADY.Services.Salary.Infrastructure.EntityConfigurations
{
   public class SalaryEntityTypeConfiguration: IEntityTypeConfiguration<Salary.Dmoain.AggregatesModel.SalaryAggregate.salary>
    {
        public void Configure(EntityTypeBuilder<Dmoain.AggregatesModel.SalaryAggregate.salary> EmpConfiguration)
        {


            EmpConfiguration.HasKey(o => o.Id);


            EmpConfiguration.Property(o => o.Id).ForSqlServerUseSequenceHiLo("SalarySeq", SalaryContext.DEFAULT_SCHEMA);

            EmpConfiguration.Property(o => o.Sal).IsRequired();


        }


    }
}
