using NArchitecture.Core.Application.Responses;

namespace Application.Features.ServiceSummaries.Commands.Create;

public class CreatedServiceSummaryResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}