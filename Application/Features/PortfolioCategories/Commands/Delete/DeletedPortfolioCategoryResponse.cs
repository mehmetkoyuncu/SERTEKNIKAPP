using NArchitecture.Core.Application.Responses;

namespace Application.Features.PortfolioCategories.Commands.Delete;

public class DeletedPortfolioCategoryResponse : IResponse
{
    public int Id { get; set; }
}