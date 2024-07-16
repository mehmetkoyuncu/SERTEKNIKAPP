using NArchitecture.Core.Application.Responses;

namespace Application.Features.PortfolioCategories.Commands.Create;

public class CreatedPortfolioCategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Text { get; set; }
}