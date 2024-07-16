using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AboutSubs.Queries.GetList;

public class GetListAboutSubListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}