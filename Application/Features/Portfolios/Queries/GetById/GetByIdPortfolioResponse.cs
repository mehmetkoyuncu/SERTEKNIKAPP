using NArchitecture.Core.Application.Responses;

namespace Application.Features.Portfolios.Queries.GetById;

public class GetByIdPortfolioResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int PortfolioCategoryId { get; set; }
}