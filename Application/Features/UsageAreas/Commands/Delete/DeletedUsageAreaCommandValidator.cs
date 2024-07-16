using FluentValidation;

namespace Application.Features.UsageAreas.Commands.Delete;

public class DeleteUsageAreaCommandValidator : AbstractValidator<DeleteUsageAreaCommand>
{
    public DeleteUsageAreaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}