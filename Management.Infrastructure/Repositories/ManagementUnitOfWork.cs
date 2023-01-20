using Management.Domain.Client;
using Management.Domain.Repositories;

namespace Management.Infrastructure.Repositories
{
    public class ManagementUnitOfWork : IManagementUnitOfWork
    {
        public ManagementUnitOfWork(
        IClientReadOnlyRepository clientReadOnlyRepository,
        IClientCommandRepository clientCommandRepository)
        {
            ClientReadOnlyRepository = clientReadOnlyRepository;
            ClientCommandRepository = clientCommandRepository;
        }

        public IClientReadOnlyRepository ClientReadOnlyRepository { get; }
        public IClientCommandRepository ClientCommandRepository { get; }
    }
}