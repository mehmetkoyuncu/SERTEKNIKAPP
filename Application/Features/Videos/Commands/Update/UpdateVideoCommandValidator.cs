using FluentValidation;

namespace Application.Features.Videos.Commands.Update;

public class UpdateVideoCommandValidator : AbstractValidator<UpdateVideoCommand>
{
    public UpdateVideoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.VideoUrl).NotEmpty();
        RuleFor(c => c.VideoType).NotEmpty();
    }
}