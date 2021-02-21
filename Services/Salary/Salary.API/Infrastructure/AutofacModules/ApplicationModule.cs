using Autofac;
using FADY.Services.Salary.API.Application.Commands;
using FADY.Services.Salary.API.Application.Queries;
using FADY.Services.Salary.Dmoain.AggregatesModel.SalaryAggregate;
using FADY.Services.Salary.Domain.AggregatesModel.AttendanceAggregate;
using FADY.Services.Salary.Infrastructure.Repository;
using System.Reflection;

namespace FADY.Services.Salary.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        :Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new SalaryQueries(QueriesConnectionString))
                .As<ISalaryQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SalaryRepository>()
                .As<ISalaryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttandceRepsoitory>()
           .As<IAttandceRepository>()
           .InstancePerLifetimeScope();

            //builder.RegisterType<OrderRepository>()
            //    .As<IOrderRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateSalaryCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
