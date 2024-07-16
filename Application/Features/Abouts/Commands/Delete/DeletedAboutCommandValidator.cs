using FluentValidation;

namespace Application.Features.Abouts.Commands.Delete;

public class DeleteAboutCommandValidator : AbstractValidator<DeleteAboutCommand>
{
    public DeleteAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}