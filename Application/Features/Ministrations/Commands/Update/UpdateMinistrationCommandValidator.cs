using FluentValidation;

namespace Application.Features.Ministrations.Commands.Update;

public class UpdateMinistrationCommandValidator : AbstractValidator<UpdateMinistrationCommand>
{
    public UpdateMinistrationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.LogoUrl).NotEmpty();
    }
}