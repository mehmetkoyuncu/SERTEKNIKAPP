using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Abouts.Queries.GetList;

public class GetListAboutListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SmallText { get; set; }
    public string ImageURL { get; set; }
}