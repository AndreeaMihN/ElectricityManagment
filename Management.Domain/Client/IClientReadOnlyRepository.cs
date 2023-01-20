namespace Management.Domain.Client
{
    public interface IClientReadOnlyRepository
    {
        //Client Get(string id);
        Task<List<Client>> GetAsync();
        Task<Client> GetAsync(string id);
    }
}
