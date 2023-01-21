using Management.Domain.Clients;

namespace Management.Domain.Repositories
{
    public interface IManagementUnitOfWork
    {
        IClientReadOnlyRepository ClientReadOnlyRepository { get; }
        IClientCommandRepository ClientCommandRepository { get; }
    }
}