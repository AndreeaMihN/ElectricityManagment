using Management.Domain.Clients;
using MediatR;

namespace Management.Application.Features.Clients.Commands.CreateClient
{
    public record CreateClientCommand(CreateClientDto createClientDto) : IRequest<bool>;
}
