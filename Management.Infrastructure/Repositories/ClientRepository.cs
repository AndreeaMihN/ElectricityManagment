using ElectricityManagment.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ElectricityManagment.Services
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientRepository(IManagmentDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);
        }
        public async Task<Client> CreateAsync(Client client)
        {
            if (client == null) throw new ArgumentNullException("client");
            await _clients.InsertOneAsync(client);
            return client;
        }

        public async Task<List<Client>> GetAsync()
        {
            return await _clients.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Client> GetAsync(string id)
        { 
            return await _clients.Find(client => client.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _clients.DeleteOneAsync(client => client.Id == id);
            return;
        }

        public async Task UpdateAsync(Client updatedClient)
        {
            await _clients.ReplaceOneAsync(client => client.Id == updatedClient.Id, updatedClient);
            return;
        }
    }
}
