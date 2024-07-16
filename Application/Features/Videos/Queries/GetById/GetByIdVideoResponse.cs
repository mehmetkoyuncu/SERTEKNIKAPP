using NArchitecture.Core.Application.Responses;

namespace Application.Features.Videos.Queries.GetById;

public class GetByIdVideoResponse : IResponse
{
    public int Id { get; set; }
    public string VideoUrl { get; set; }
    public string VideoType { get; set; }
}