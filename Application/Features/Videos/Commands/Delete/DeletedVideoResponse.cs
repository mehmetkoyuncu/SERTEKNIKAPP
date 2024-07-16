using NArchitecture.Core.Application.Responses;

namespace Application.Features.Videos.Commands.Delete;

public class DeletedVideoResponse : IResponse
{
    public int Id { get; set; }
}