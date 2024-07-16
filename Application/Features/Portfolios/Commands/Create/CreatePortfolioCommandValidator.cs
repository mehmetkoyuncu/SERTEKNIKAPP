using FluentValidation;

namespace Application.Features.Portfolios.Commands.Create;

public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
{
    public CreatePortfolioCommandValidator()
    {
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.PortfolioCategoryId).NotEmpty();
    }
}