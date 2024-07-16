using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Ministrations.Queries.GetList;

public class GetListMinistrationListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}