using FluentValidation;

namespace Application.Features.AboutSubs.Commands.Delete;

public class DeleteAboutSubCommandValidator : AbstractValidator<DeleteAboutSubCommand>
{
    public DeleteAboutSubCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}