using MediatR;

namespace Management.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<bool>
    {
        public CreateClientDto CreateClientDto { get; set; }
    }
}
