using FluentValidation;

namespace Application.Features.SampleEntities.Commands.Update;

public class UpdateSampleEntityCommandValidator : AbstractValidator<UpdateSampleEntityCommand>
{
    public UpdateSampleEntityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.X).NotEmpty();
    }
}