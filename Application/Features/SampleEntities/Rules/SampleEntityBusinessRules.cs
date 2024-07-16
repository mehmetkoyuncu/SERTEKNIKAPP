using Application.Features.SampleEntities.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SampleEntities.Rules;

public class SampleEntityBusinessRules : BaseBusinessRules
{
    private readonly ISampleEntityRepository _sampleEntityRepository;
    private readonly ILocalizationService _localizationService;

    public SampleEntityBusinessRules(ISampleEntityRepository sampleEntityRepository, ILocalizationService localizationService)
    {
        _sampleEntityRepository = sampleEntityRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SampleEntitiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SampleEntityShouldExistWhenSelected(SampleEntity? sampleEntity)
    {
        if (sampleEntity == null)
            await throwBusinessException(SampleEntitiesBusinessMessages.SampleEntityNotExists);
    }

    public async Task SampleEntityIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SampleEntity? sampleEntity = await _sampleEntityRepository.GetAsync(
            predicate: se => se.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SampleEntityShouldExistWhenSelected(sampleEntity);
    }
}