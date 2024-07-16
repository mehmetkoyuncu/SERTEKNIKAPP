using FluentValidation;

namespace Application.Features.Abouts.Commands.Update;

public class UpdateAboutCommandValidator : AbstractValidator<UpdateAboutCommand>
{
    public UpdateAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.SmallText).NotEmpty();
        RuleFor(c => c.ImageURL).NotEmpty();
    }
}