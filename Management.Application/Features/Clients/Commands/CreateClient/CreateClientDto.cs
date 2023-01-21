using AutoMapper;
using Management.Domain.Clients;

namespace Management.Application.Features.Clients.Commands.CreateClient
{
    [AutoMap(typeof(Client), ReverseMap = true)]
    public class CreateClientDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public CreateClientDto()
        {
        }

        public CreateClientDto(CreateClientDto createClientDto)
        {
            FirstName = createClientDto.FirstName;
            LastName = createClientDto.LastName;
            PersonalIdentificationNumber = createClientDto.PersonalIdentificationNumber;
        }

        //public CreateClientDto(CreateClientDto createClientDto, string userId)
        //{
        //    Content = createClientDto.Content;
        //    Uploads = createClientDto.Uploads;
        //    UserId = userId;
        //}
    }
}