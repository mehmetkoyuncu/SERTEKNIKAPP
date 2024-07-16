using NArchitecture.Core.Application.Responses;

namespace Application.Features.SampleEntities.Queries.GetById;

public class GetByIdSampleEntityResponse : IResponse
{
    public int Id { get; set; }
    public int X { get; set; }
}