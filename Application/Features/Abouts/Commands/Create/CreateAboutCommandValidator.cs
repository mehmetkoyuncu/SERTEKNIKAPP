using FluentValidation;

namespace Application.Features.Abouts.Commands.Create;

public class CreateAboutCommandValidator : AbstractValidator<CreateAboutCommand>
{
    public CreateAboutCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Giriniz");
        RuleFor(c => c.SmallText).NotEmpty().MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Giriniz");
        RuleFor(c => c.ImagePath).NotEmpty();
    }
}