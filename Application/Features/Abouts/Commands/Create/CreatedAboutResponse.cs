using NArchitecture.Core.Application.Responses;

namespace Application.Features.Abouts.Commands.Create;

public class CreatedAboutResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SmallText { get; set; }
    public string ImageURL { get; set; }
}