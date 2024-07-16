using Application.Features.Abouts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Abouts.Rules;

public class AboutBusinessRules : BaseBusinessRules
{
    private readonly IAboutRepository _aboutRepository;
    private readonly ILocalizationService _localizationService;

    public AboutBusinessRules(IAboutRepository aboutRepository, ILocalizationService localizationService)
    {
        _aboutRepository = aboutRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AboutsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AboutShouldExistWhenSelected(About? about)
    {
        if (about == null)
            await throwBusinessException(AboutsBusinessMessages.AboutNotExists);
    }

    public async Task AboutIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        About? about = await _aboutRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AboutShouldExistWhenSelected(about);
    }
}