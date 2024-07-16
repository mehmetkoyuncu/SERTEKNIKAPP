using FluentValidation;

namespace Application.Features.Portfolios.Commands.Update;

public class UpdatePortfolioCommandValidator : AbstractValidator<UpdatePortfolioCommand>
{
    public UpdatePortfolioCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.PortfolioCategoryId).NotEmpty();
    }
}