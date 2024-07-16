using FluentValidation;

namespace Application.Features.UsageAreas.Commands.Create;

public class CreateUsageAreaCommandValidator : AbstractValidator<CreateUsageAreaCommand>
{
    public CreateUsageAreaCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}