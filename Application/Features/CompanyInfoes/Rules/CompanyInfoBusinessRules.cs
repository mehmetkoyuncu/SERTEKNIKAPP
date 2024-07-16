using Application.Features.CompanyInfoes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyInfoes.Rules;

public class CompanyInfoBusinessRules : BaseBusinessRules
{
    private readonly ICompanyInfoRepository _companyInfoRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyInfoBusinessRules(ICompanyInfoRepository companyInfoRepository, ILocalizationService localizationService)
    {
        _companyInfoRepository = companyInfoRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyInfoesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyInfoShouldExistWhenSelected(CompanyInfo? companyInfo)
    {
        if (companyInfo == null)
            await throwBusinessException(CompanyInfoesBusinessMessages.CompanyInfoNotExists);
    }

    public async Task CompanyInfoIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyInfo? companyInfo = await _companyInfoRepository.GetAsync(
            predicate: ci => ci.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyInfoShouldExistWhenSelected(companyInfo);
    }
}