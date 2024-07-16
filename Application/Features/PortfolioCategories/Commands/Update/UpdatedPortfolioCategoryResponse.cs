using NArchitecture.Core.Application.Responses;

namespace Application.Features.PortfolioCategories.Commands.Update;

public class UpdatedPortfolioCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
}