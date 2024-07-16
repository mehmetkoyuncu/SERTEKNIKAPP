using FluentValidation;

namespace Application.Features.UsageAreas.Commands.Update;

public class UpdateUsageAreaCommandValidator : AbstractValidator<UpdateUsageAreaCommand>
{
    public UpdateUsageAreaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.LogoUrl).NotEmpty();
    }
}