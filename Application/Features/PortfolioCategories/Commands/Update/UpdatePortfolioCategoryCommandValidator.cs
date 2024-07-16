using FluentValidation;

namespace Application.Features.PortfolioCategories.Commands.Update;

public class UpdatePortfolioCategoryCommandValidator : AbstractValidator<UpdatePortfolioCategoryCommand>
{
    public UpdatePortfolioCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
    }
}