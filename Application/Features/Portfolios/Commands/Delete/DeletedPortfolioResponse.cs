using NArchitecture.Core.Application.Responses;

namespace Application.Features.Portfolios.Commands.Delete;

public class DeletedPortfolioResponse : IResponse
{
    public int Id { get; set; }
}