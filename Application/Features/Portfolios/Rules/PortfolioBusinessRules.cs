using Application.Features.Portfolios.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Portfolios.Rules;

public class PortfolioBusinessRules : BaseBusinessRules
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly ILocalizationService _localizationService;

    public PortfolioBusinessRules(IPortfolioRepository portfolioRepository, ILocalizationService localizationService)
    {
        _portfolioRepository = portfolioRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PortfoliosBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PortfolioShouldExistWhenSelected(Portfolio? portfolio)
    {
        if (portfolio == null)
            await throwBusinessException(PortfoliosBusinessMessages.PortfolioNotExists);
    }

    public async Task PortfolioIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Portfolio? portfolio = await _portfolioRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PortfolioShouldExistWhenSelected(portfolio);
    }
}