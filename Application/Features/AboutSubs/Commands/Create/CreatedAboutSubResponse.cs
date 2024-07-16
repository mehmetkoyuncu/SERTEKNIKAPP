using NArchitecture.Core.Application.Responses;

namespace Application.Features.AboutSubs.Commands.Create;

public class CreatedAboutSubResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}