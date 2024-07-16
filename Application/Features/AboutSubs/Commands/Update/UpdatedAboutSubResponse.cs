using NArchitecture.Core.Application.Responses;

namespace Application.Features.AboutSubs.Commands.Update;

public class UpdatedAboutSubResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}