using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Portfolios.Queries.GetList;

public class GetListPortfolioListItemDto : IDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int PortfolioCategoryId { get; set; }
}