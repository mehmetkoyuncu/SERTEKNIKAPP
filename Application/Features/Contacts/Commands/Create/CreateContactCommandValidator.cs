using FluentValidation;

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(c => c.Mail).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.PhoneNumber1).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.MapsLat).NotEmpty();
        RuleFor(c => c.MapsLen).NotEmpty();
    }
}