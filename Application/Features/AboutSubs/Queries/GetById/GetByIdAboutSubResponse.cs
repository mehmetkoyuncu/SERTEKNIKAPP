using NArchitecture.Core.Application.Responses;

namespace Application.Features.AboutSubs.Queries.GetById;

public class GetByIdAboutSubResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}