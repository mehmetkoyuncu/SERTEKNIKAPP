using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ServiceSummaries.Queries.GetList;

public class GetListServiceSummaryListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}