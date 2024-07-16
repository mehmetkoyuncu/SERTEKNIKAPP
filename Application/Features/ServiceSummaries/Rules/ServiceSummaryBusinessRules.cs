using Application.Features.ServiceSummaries.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ServiceSummaries.Rules;

public class ServiceSummaryBusinessRules : BaseBusinessRules
{
    private readonly IServiceSummaryRepository _serviceSummaryRepository;
    private readonly ILocalizationService _localizationService;

    public ServiceSummaryBusinessRules(IServiceSummaryRepository serviceSummaryRepository, ILocalizationService localizationService)
    {
        _serviceSummaryRepository = serviceSummaryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ServiceSummariesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ServiceSummaryShouldExistWhenSelected(ServiceSummary? serviceSummary)
    {
        if (serviceSummary == null)
            await throwBusinessException(ServiceSummariesBusinessMessages.ServiceSummaryNotExists);
    }

    public async Task ServiceSummaryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ServiceSummary? serviceSummary = await _serviceSummaryRepository.GetAsync(
            predicate: ss => ss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ServiceSummaryShouldExistWhenSelected(serviceSummary);
    }
}