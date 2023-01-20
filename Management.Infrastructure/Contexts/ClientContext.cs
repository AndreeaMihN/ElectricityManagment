using Management.Models;
using Management.Domain.Client;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Management.Infrastructure.Contexts
{
    public interface IClientContext
    {
        IMongoCollection<Client> Clients { get; }
    }
    public class ClientContext : IClientContext
    {
        private readonly IMongoDatabase db;

        public ClientContext(IOptions<ClientConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Client> Clients => db.GetCollection<Client>("Clients");
    }
}