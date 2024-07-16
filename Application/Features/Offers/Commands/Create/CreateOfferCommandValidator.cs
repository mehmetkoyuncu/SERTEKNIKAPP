using FluentValidation;

namespace Application.Features.Offers.Commands.Create;

public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
{
    public CreateOfferCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.ProjectName).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}