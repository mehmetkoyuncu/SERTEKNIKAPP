using FluentValidation;

namespace Application.Features.ServiceSummaries.Commands.Update;

public class UpdateServiceSummaryCommandValidator : AbstractValidator<UpdateServiceSummaryCommand>
{
    public UpdateServiceSummaryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}