using Autofac;
using FADY.Services.Employee.API.Application.Commands;
using FADY.Services.Employee.API.Application.Queries;
using FADY.Services.Employee.Dmoain.AggregatesModel.EmployeeAggregate;
using FADY.Services.Employee.Infrastructure.Repository;
using System.Reflection;

namespace FADY.Services.Employee.API.Infrastructure.AutofacModules
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

            builder.Register(c => new EmployeeQueries(QueriesConnectionString))
                .As<IEmployeeQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

           // builder.RegisterAssemblyTypes(typeof(CreateEmployeePermanentCommand).GetTypeInfo().Assembly)
             //   .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
