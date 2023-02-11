using Management.Domain.Clients;
using MediatR;

namespace Management.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<Client>
    {
        public CreateClientDto CreateClientDto { get; set; }
    }
}
