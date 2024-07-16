using NArchitecture.Core.Application.Responses;

namespace Application.Features.Portfolios.Commands.Create;

public class CreatedPortfolioResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int PortfolioCategoryId { get; set; }
}