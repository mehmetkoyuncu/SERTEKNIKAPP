using NArchitecture.Core.Application.Responses;

namespace Application.Features.Abouts.Commands.Delete;

public class DeletedAboutResponse : IResponse
{
    public int Id { get; set; }
}