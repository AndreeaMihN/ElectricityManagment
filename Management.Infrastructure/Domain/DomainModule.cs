using Autofac;
using Management.Domain.Clients;
using Management.Domain.Repositories;
using Management.Infrastructure.Domain.Clients;
using Management.Infrastructure.Repositories;
using Management.Infrastruncture.Domain.Clients;

namespace Management.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ManagementUnitOfWork>().As<IManagementUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ClientReadOnlyRepository>().As<IClientReadOnlyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ClientCommandRepository>().As<IClientCommandRepository>().InstancePerLifetimeScope();
        }
    }
}
