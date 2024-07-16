using FluentValidation;

namespace Application.Features.CompanyInfoes.Commands.Update;

public class UpdateCompanyInfoCommandValidator : AbstractValidator<UpdateCompanyInfoCommand>
{
    public UpdateCompanyInfoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LogoUrl).NotEmpty();
        RuleFor(c => c.Mail).NotEmpty();
        RuleFor(c => c.Phone1).NotEmpty();
        RuleFor(c => c.Phone2).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.GoogleMapAddress).NotEmpty();
    }
}