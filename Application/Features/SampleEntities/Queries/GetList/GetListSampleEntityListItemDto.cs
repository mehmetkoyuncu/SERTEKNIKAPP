using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SampleEntities.Queries.GetList;

public class GetListSampleEntityListItemDto : IDto
{
    public int Id { get; set; }
    public int X { get; set; }
}