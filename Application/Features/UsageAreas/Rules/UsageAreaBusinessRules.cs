using Application.Features.UsageAreas.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UsageAreas.Rules;

public class UsageAreaBusinessRules : BaseBusinessRules
{
    private readonly IUsageAreaRepository _usageAreaRepository;
    private readonly ILocalizationService _localizationService;

    public UsageAreaBusinessRules(IUsageAreaRepository usageAreaRepository, ILocalizationService localizationService)
    {
        _usageAreaRepository = usageAreaRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UsageAreasBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UsageAreaShouldExistWhenSelected(UsageArea? usageArea)
    {
        if (usageArea == null)
            await throwBusinessException(UsageAreasBusinessMessages.UsageAreaNotExists);
    }

    public async Task UsageAreaIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UsageArea? usageArea = await _usageAreaRepository.GetAsync(
            predicate: ua => ua.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UsageAreaShouldExistWhenSelected(usageArea);
    }
}