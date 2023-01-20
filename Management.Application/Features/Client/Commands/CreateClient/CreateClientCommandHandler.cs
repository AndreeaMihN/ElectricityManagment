using AutoMapper;
using Management.Application.Features.Client.Commands.CreateClient;
using Management.Domain.Repositories;
using Management.Domain.Client;
using MediatR;

namespace Management.Application.Client.Commands.CreateClient
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
            Client entity = _mapper.Map<Client>(request.CreateClientDto);
            entity.IsActive = false;
            try
            {
                _clientUnitOfWork.ClientCommandRepository.Create(entity);
            }
            catch
            {
                throw new Exception.ApplicationException("Failed to add a new client");
            }

            return true;
        }
    }
}
