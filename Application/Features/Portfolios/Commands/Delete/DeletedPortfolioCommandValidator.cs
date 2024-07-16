using FluentValidation;

namespace Application.Features.Portfolios.Commands.Delete;

public class DeletePortfolioCommandValidator : AbstractValidator<DeletePortfolioCommand>
{
    public DeletePortfolioCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}