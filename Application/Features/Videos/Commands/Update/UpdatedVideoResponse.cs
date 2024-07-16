using NArchitecture.Core.Application.Responses;

namespace Application.Features.Videos.Commands.Update;

public class UpdatedVideoResponse : IResponse
{
    public int Id { get; set; }
    public string VideoUrl { get; set; }
    public string VideoType { get; set; }
}