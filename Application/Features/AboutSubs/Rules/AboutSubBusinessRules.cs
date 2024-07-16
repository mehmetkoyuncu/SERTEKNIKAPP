using Application.Features.AboutSubs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AboutSubs.Rules;

public class AboutSubBusinessRules : BaseBusinessRules
{
    private readonly IAboutSubRepository _aboutSubRepository;
    private readonly ILocalizationService _localizationService;

    public AboutSubBusinessRules(IAboutSubRepository aboutSubRepository, ILocalizationService localizationService)
    {
        _aboutSubRepository = aboutSubRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AboutSubsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AboutSubShouldExistWhenSelected(AboutSub? aboutSub)
    {
        if (aboutSub == null)
            await throwBusinessException(AboutSubsBusinessMessages.AboutSubNotExists);
    }

    public async Task AboutSubIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AboutSub? aboutSub = await _aboutSubRepository.GetAsync(
            predicate: ass => ass.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AboutSubShouldExistWhenSelected(aboutSub);
    }
}