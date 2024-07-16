using NArchitecture.Core.Application.Responses;

namespace Application.Features.UsageAreas.Commands.Create;

public class CreatedUsageAreaResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}