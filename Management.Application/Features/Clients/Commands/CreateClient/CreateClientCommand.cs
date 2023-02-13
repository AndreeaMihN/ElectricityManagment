using Management.Domain.Clients;
using MediatR;

namespace Management.Application.Features.Clients.Commands.CreateClient
{
    public record CreateClientCommand(Client Client) : IRequest<Client>;
}
