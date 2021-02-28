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
   public class EmployeeEntityTypeConfiguration: IEntityTypeConfiguration<Employee.Dmoain.AggregatesModel.EmployeeAggregate.Employe>
    {
        public void Configure(EntityTypeBuilder<Dmoain.AggregatesModel.EmployeeAggregate.Employe> EmpConfiguration)
        {
         
            EmpConfiguration.HasKey(o => o.Id);
        
            EmpConfiguration.Ignore(b => b.DomainEvents);

            EmpConfiguration.OwnsOne(o => o.Address,
                sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("Address_Street");
                    sa.Property(p => p.City).HasColumnName("Address_City");
                    sa.Property(p => p.Country).HasColumnName("Address_Country");
                }); ;
            EmpConfiguration.Property(o => o.Name).HasMaxLength(100);
            EmpConfiguration.Property(o => o.Phone).IsRequired();
           


        }


    }
}
