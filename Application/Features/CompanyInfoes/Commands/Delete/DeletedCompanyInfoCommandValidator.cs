using FluentValidation;

namespace Application.Features.CompanyInfoes.Commands.Delete;

public class DeleteCompanyInfoCommandValidator : AbstractValidator<DeleteCompanyInfoCommand>
{
    public DeleteCompanyInfoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}