using FluentValidation;

namespace Application.Features.ServiceSummaries.Commands.Delete;

public class DeleteServiceSummaryCommandValidator : AbstractValidator<DeleteServiceSummaryCommand>
{
    public DeleteServiceSummaryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}