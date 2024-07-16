using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PortfolioCategories.Queries.GetList;

public class GetListPortfolioCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public string Text { get; set; }
}