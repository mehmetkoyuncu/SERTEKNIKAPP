using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ministrations.Commands.Delete;

public class DeletedMinistrationResponse : IResponse
{
    public int Id { get; set; }
}