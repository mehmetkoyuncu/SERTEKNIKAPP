using NArchitecture.Core.Application.Responses;

namespace Application.Features.ServiceSummaries.Queries.GetById;

public class GetByIdServiceSummaryResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}