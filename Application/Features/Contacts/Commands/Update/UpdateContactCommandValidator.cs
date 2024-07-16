using FluentValidation;

namespace Application.Features.Contacts.Commands.Update;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Mail).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.PhoneNumber1).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.MapsLat).NotEmpty();
        RuleFor(c => c.MapsLen).NotEmpty();
    }
}