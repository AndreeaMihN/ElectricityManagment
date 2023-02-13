using AutoMapper;
using Management.Domain.Clients;
using Management.Domain.Repositories;
using MediatR;

namespace Management.Application.Features.Clients.Commands.CreateClient
{

    public class CreateClientHandler : IRequestHandler<CreateClientCommand, bool>
    {
        private readonly IManagementUnitOfWork _clientUnitOfWork;
        private readonly IMapper _mapper;

        public CreateClientHandler(IManagementUnitOfWork clientUnitOfWork, IMapper mapper)
        {
            _clientUnitOfWork = clientUnitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            Client entity = _mapper.Map<Client>(request.createClientDto);
            entity.IsActive = false;
            try
            {
                await _clientUnitOfWork.ClientCommandRepository.CreateAsync(entity);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to add a new client");
            }

            return true;
        }
    }
}
