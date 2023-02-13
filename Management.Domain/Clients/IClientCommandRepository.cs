namespace Management.Domain.Clients
{
    public interface IClientCommandRepository
    {
        //void Create(Client entity);
        //bool Update(Client entity);
        //bool Delete(string id);
        Task CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task RemoveAsync(string id);
    }
}
