using FluentValidation;

namespace Application.Features.AboutSubs.Commands.Update;

public class UpdateAboutSubCommandValidator : AbstractValidator<UpdateAboutSubCommand>
{
    public UpdateAboutSubCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}