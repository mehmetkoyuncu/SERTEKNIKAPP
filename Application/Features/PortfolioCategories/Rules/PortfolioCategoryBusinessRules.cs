using Application.Features.PortfolioCategories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PortfolioCategories.Rules;

public class PortfolioCategoryBusinessRules : BaseBusinessRules
{
    private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
    private readonly ILocalizationService _localizationService;

    public PortfolioCategoryBusinessRules(IPortfolioCategoryRepository portfolioCategoryRepository, ILocalizationService localizationService)
    {
        _portfolioCategoryRepository = portfolioCategoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PortfolioCategoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PortfolioCategoryShouldExistWhenSelected(PortfolioCategory? portfolioCategory)
    {
        if (portfolioCategory == null)
            await throwBusinessException(PortfolioCategoriesBusinessMessages.PortfolioCategoryNotExists);
    }

    public async Task PortfolioCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        PortfolioCategory? portfolioCategory = await _portfolioCategoryRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PortfolioCategoryShouldExistWhenSelected(portfolioCategory);
    }
}