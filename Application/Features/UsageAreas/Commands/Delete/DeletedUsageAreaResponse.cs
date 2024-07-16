using NArchitecture.Core.Application.Responses;

namespace Application.Features.UsageAreas.Commands.Delete;

public class DeletedUsageAreaResponse : IResponse
{
    public int Id { get; set; }
}