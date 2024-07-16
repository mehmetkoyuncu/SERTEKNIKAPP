using NArchitecture.Core.Application.Responses;

namespace Application.Features.SampleEntities.Commands.Delete;

public class DeletedSampleEntityResponse : IResponse
{
    public int Id { get; set; }
}