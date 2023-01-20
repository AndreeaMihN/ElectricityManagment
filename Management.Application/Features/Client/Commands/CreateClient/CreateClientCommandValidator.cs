using Management.Application.Features.Client.Commands.CreateClient;
using FluentValidation;

namespace Management.Application.Client.Commands.CreateClient
{
    public class CreateClientCommandValidator
    {
        RuleFor(model => Model.CreateClientDto.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Please ensure you have entered 'FirstName' field")
            .NotEmpty().WithMessage("Content field shouldn't be empty");

        RuleFor(model => model.CreateClientDto.LastName)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Please ensure you have entered 'LastName' field")
            .NotEmpty().WithMessage("Content field shouldn't be empty");

        RuleFor(model => model.CreateClientDto.PersonalIdentificationNumber)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Please ensure you have entered 'PersonalIdentificationNumber' field")
            .NotEmpty().WithMessage("Content field shouldn't be empty");
    }
}
