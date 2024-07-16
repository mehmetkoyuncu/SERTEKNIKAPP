using NArchitecture.Core.Application.Responses;

namespace Application.Features.ServiceSummaries.Commands.Update;

public class UpdatedServiceSummaryResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}