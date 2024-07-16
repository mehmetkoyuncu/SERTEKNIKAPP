using NArchitecture.Core.Application.Responses;

namespace Application.Features.AboutSubs.Commands.Delete;

public class DeletedAboutSubResponse : IResponse
{
    public int Id { get; set; }
}