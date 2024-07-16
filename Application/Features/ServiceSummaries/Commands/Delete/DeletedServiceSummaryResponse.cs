using NArchitecture.Core.Application.Responses;

namespace Application.Features.ServiceSummaries.Commands.Delete;

public class DeletedServiceSummaryResponse : IResponse
{
    public int Id { get; set; }
}