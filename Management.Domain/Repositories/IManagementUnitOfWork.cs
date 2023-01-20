using Management.Domain.Client;
namespace Management.Domain.Repositories
{
    public interface IManagementUnitOfWork
    {
        IClientReadOnlyRepository ClientReadOnlyRepository { get; }
        IClientCommandRepository ClientCommandRepository { get; }
    }
}