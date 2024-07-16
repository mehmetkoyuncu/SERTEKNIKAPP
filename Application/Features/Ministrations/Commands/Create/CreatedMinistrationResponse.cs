using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ministrations.Commands.Create;

public class CreatedMinistrationResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}