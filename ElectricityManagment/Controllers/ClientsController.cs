using ElectricityManagment.Models;
using ElectricityManagment.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<List<Client>> Get()
        {
            return await clientRepository.GetAsync();
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<Client> Get(string id)
        {
            var client = await clientRepository.GetAsync(id);
            return client;
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            await clientRepository.CreateAsync(client);
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Client client)
        {
            if(client.Id == null) throw new ArgumentNullException(nameof(client.Id));
            var existingClient = await clientRepository.GetAsync(client.Id);
            if (existingClient == null)
            {
                return NotFound($"Client with Id = {client.Id} not found");
            }
            await clientRepository.UpdateAsync(client);
            return NoContent();
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = await clientRepository.GetAsync(id);
            if (client == null)
            {
                return NotFound($"Client with Id = {id} not found");
            }
            if (client.Id == null) throw new ArgumentNullException(nameof(client.Id));
            await clientRepository.RemoveAsync(client.Id);
            return Ok($"Client with Id = {id} deleted");
        }
    }
}
