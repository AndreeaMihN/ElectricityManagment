using Management.Api.Controllers;
using Management.Application.Features.Clients.Commands.CreateClient;
using Management.Domain.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        private readonly IMediator _mediator;

        public ClientController(IClientCommandRepository clientCommandRepository, IMediator mediator)
        {
            _clientCommandRepository = clientCommandRepository;
            _mediator = mediator;
        }
        //// GET: api/<ClientsController>
        //[HttpGet]
        //public async Task<List<Client>> Get()
        //{
        //    return await clientRepository.GetAsync();
        //}

        //GET api/<ClientsController>/5
        //[HttpGet("{id}")]
        //public async Task<Client> Get(string id)
        //{
        //    var client = await clientRepository.GetAsync(id);
        //    return client;
        //}

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] Client client)
        {
            //var result = await _mediator.Send(new CreateClientCommand(client));
            await _mediator.Send(new CreateClientCommand(client));

            return Ok(201);
        }

        // PUT api/<ClientsController>/5
        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] Client client)
        //{
        //    if(client.Id == null) throw new ArgumentNullException(nameof(client.Id));
        //    var existingClient = await clientRepository.GetAsync(client.Id);
        //    if (existingClient == null)
        //    {
        //        return NotFound($"Client with Id = {client.Id} not found");
        //    }
        //    await clientRepository.UpdateAsync(client);
        //    return NoContent();
        //}

        // DELETE api/<ClientsController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var client = await clientRepository.GetAsync(id);
        //    if (client == null)
        //    {
        //        return NotFound($"Client with Id = {id} not found");
        //    }
        //    if (client.Id == null) throw new ArgumentNullException(nameof(client.Id));
        //    await clientRepository.RemoveAsync(client.Id);
        //    return Ok($"Client with Id = {id} deleted");
        //}
    }
}
