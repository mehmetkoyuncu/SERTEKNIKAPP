using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UsageAreas.Queries.GetList;

public class GetListUsageAreaListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}