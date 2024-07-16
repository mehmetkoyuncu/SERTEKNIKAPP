using FluentValidation;

namespace Application.Features.ServiceSummaries.Commands.Create;

public class CreateServiceSummaryCommandValidator : AbstractValidator<CreateServiceSummaryCommand>
{
    public CreateServiceSummaryCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}