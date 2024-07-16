using Application.Features.Ministrations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Ministrations.Rules;

public class MinistrationBusinessRules : BaseBusinessRules
{
    private readonly IMinistrationRepository _ministrationRepository;
    private readonly ILocalizationService _localizationService;

    public MinistrationBusinessRules(IMinistrationRepository ministrationRepository, ILocalizationService localizationService)
    {
        _ministrationRepository = ministrationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MinistrationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MinistrationShouldExistWhenSelected(Ministration? ministration)
    {
        if (ministration == null)
            await throwBusinessException(MinistrationsBusinessMessages.MinistrationNotExists);
    }

    public async Task MinistrationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Ministration? ministration = await _ministrationRepository.GetAsync(
            predicate: m => m.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MinistrationShouldExistWhenSelected(ministration);
    }
}