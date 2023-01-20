using MongoDB.Bson;
using MongoDB.Driver;
using Management.Infrastructure.Contexts;

namespace Management.Infrastruncture.Domain.Client
{
	public class ClientReadOnlyRepository : IClientReadOnlyRepository
    {
		private readonly IClientContext _context;

		public ClientReadOnlyRepository(IClientContext context)
		{
			_context = context;

		}
		public async Task<List<Client>> GetAsync()
		{
			return await _context.Clients.Find(new BsonDocument()).ToListAsync();
		}

		public async Task<Client> GetAsync(string id)
		{
			return await _context.Clients.Find(client => client.Id == id).FirstOrDefaultAsync();
		}

    }
}
