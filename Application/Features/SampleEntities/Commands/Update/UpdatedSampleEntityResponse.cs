using NArchitecture.Core.Application.Responses;

namespace Application.Features.SampleEntities.Commands.Update;

public class UpdatedSampleEntityResponse : IResponse
{
    public int Id { get; set; }
    public int X { get; set; }
}