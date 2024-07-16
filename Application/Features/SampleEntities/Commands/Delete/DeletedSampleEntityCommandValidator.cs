using FluentValidation;

namespace Application.Features.SampleEntities.Commands.Delete;

public class DeleteSampleEntityCommandValidator : AbstractValidator<DeleteSampleEntityCommand>
{
    public DeleteSampleEntityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}