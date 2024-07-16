using FluentValidation;

namespace Application.Features.Videos.Commands.Create;

public class CreateVideoCommandValidator : AbstractValidator<CreateVideoCommand>
{
    public CreateVideoCommandValidator()
    {
        RuleFor(c => c.VideoFile).NotEmpty();
        RuleFor(c => c.VideoType).NotEmpty();
    }
}