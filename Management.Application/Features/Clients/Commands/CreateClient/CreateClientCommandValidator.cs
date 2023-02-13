using FluentValidation;

namespace Management.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(model => model.Client.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'FirstName' field")
                .NotEmpty().WithMessage("Content field shouldn't be empty");

            RuleFor(model => model.Client.LastName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'LastName' field")
                .NotEmpty().WithMessage("Content field shouldn't be empty");

            RuleFor(model => model.Client.PersonalIdentificationNumber)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please ensure you have entered 'PersonalIdentificationNumber' field")
                .NotEmpty().WithMessage("Content field shouldn't be empty");
        }
    }
}