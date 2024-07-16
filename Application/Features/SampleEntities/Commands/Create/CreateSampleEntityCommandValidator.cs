using FluentValidation;

namespace Application.Features.SampleEntities.Commands.Create;

public class CreateSampleEntityCommandValidator : AbstractValidator<CreateSampleEntityCommand>
{
    public CreateSampleEntityCommandValidator()
    {
        RuleFor(c => c.X).NotEmpty();
    }
}