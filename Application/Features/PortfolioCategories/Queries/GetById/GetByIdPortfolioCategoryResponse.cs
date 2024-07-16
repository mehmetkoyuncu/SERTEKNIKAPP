using Application.Features.Portfolios.Queries.GetById;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.PortfolioCategories.Queries.GetById;

public class GetByIdPortfolioCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
    public ICollection<GetByIdPortfolioResponse > Portfolios { get; set; }
}