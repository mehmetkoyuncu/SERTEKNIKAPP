using FluentValidation;

namespace Application.Features.AboutSubs.Commands.Create;

public class CreateAboutSubCommandValidator : AbstractValidator<CreateAboutSubCommand>
{
    public CreateAboutSubCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}