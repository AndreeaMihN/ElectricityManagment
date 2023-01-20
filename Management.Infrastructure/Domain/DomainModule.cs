using Autofac;
using Management.Infrastruncture.Domain.Client;
using Management.Domain.Repositories;
using Management.Domain.Client;
using Management.Infrastructure.Repositories;
using Management.Infrastructure.Domain.Client;

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
