using FluentValidation;

namespace Application.Features.Ministrations.Commands.Delete;

public class DeleteMinistrationCommandValidator : AbstractValidator<DeleteMinistrationCommand>
{
    public DeleteMinistrationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}