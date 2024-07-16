using FluentValidation;

namespace Application.Features.PortfolioCategories.Commands.Delete;

public class DeletePortfolioCategoryCommandValidator : AbstractValidator<DeletePortfolioCategoryCommand>
{
    public DeletePortfolioCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}