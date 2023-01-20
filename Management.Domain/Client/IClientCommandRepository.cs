namespace Management.Domain.Client
{
    public interface IClientCommandRepository
    {
        //void Create(Client entity);
        //bool Update(Client entity);
        //bool Delete(string id);
        Task<Client> CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task RemoveAsync(string id);
    }
}
