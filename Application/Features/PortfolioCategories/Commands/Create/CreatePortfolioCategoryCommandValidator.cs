using FluentValidation;

namespace Application.Features.PortfolioCategories.Commands.Create;

public class CreatePortfolioCategoryCommandValidator : AbstractValidator<CreatePortfolioCategoryCommand>
{
    public CreatePortfolioCategoryCommandValidator()
    {
        RuleFor(c => c.Text).NotEmpty();
    }
}