using FluentValidation;

namespace Application.Features.Ministrations.Commands.Create;

public class CreateMinistrationCommandValidator : AbstractValidator<CreateMinistrationCommand>
{
    public CreateMinistrationCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}