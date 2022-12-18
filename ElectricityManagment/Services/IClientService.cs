using ElectricityManagment.Models;

namespace ElectricityManagment.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAsync();
        Task<Client> GetAsync(string id);
        Task<Client> CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task RemoveAsync(string id);
    }
}

