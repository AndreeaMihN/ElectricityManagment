using AutoMapper;
using Management.Domain.Clients;
using Management.Domain.Repositories;
using MediatR;

namespace Management.Application.Features.Clients.Commands.CreateClient
{

    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IManagementUnitOfWork _clientUnitOfWork;
        private readonly IMapper _mapper;

        public CreateClientHandler(IManagementUnitOfWork clientUnitOfWork, IMapper mapper)
        {
            _clientUnitOfWork = clientUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            Client entity = _mapper.Map<Client>(request.Client);
            entity.IsActive = false;
            try
            {
                await _clientUnitOfWork.ClientCommandRepository.CreateAsync(entity);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to add a new client");
            }

            return request.Client;
        }
    }
}
