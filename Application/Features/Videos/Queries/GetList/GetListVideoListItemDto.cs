using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Videos.Queries.GetList;

public class GetListVideoListItemDto : IDto
{
    public int Id { get; set; }
    public string VideoUrl { get; set; }
    public string VideoType { get; set; }
}