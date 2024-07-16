using FluentValidation;

namespace Application.Features.CompanyInfoes.Commands.Create;

public class CreateCompanyInfoCommandValidator : AbstractValidator<CreateCompanyInfoCommand>
{
    public CreateCompanyInfoCommandValidator()
    {
        RuleFor(c => c.FormFile).NotEmpty();
        RuleFor(c => c.Mail).NotEmpty();
        RuleFor(c => c.Phone1).NotEmpty();
        RuleFor(c => c.Phone2).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.GoogleMapAddress).NotEmpty();
    }
}