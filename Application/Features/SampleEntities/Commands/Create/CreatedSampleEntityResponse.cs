using NArchitecture.Core.Application.Responses;

namespace Application.Features.SampleEntities.Commands.Create;

public class CreatedSampleEntityResponse : IResponse
{
    public int Id { get; set; }
    public int X { get; set; }
}