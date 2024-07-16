using Application.Features.CompanyInfoes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyInfoes;

public class CompanyInfoManager : ICompanyInfoService
{
    private readonly ICompanyInfoRepository _companyInfoRepository;
    private readonly CompanyInfoBusinessRules _companyInfoBusinessRules;

    public CompanyInfoManager(ICompanyInfoRepository companyInfoRepository, CompanyInfoBusinessRules companyInfoBusinessRules)
    {
        _companyInfoRepository = companyInfoRepository;
        _companyInfoBusinessRules = companyInfoBusinessRules;
    }

    public async Task<CompanyInfo?> GetAsync(
        Expression<Func<CompanyInfo, bool>> predicate,
        Func<IQueryable<CompanyInfo>, IIncludableQueryable<CompanyInfo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CompanyInfo? companyInfo = await _companyInfoRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return companyInfo;
    }

    public async Task<IPaginate<CompanyInfo>?> GetListAsync(
        Expression<Func<CompanyInfo, bool>>? predicate = null,
        Func<IQueryable<CompanyInfo>, IOrderedQueryable<CompanyInfo>>? orderBy = null,
        Func<IQueryable<CompanyInfo>, IIncludableQueryable<CompanyInfo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CompanyInfo> companyInfoList = await _companyInfoRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyInfoList;
    }

    public async Task<CompanyInfo> AddAsync(CompanyInfo companyInfo)
    {
        CompanyInfo addedCompanyInfo = await _companyInfoRepository.AddAsync(companyInfo);

        return addedCompanyInfo;
    }

    public async Task<CompanyInfo> UpdateAsync(CompanyInfo companyInfo)
    {
        CompanyInfo updatedCompanyInfo = await _companyInfoRepository.UpdateAsync(companyInfo);

        return updatedCompanyInfo;
    }

    public async Task<CompanyInfo> DeleteAsync(CompanyInfo companyInfo, bool permanent = false)
    {
        CompanyInfo deletedCompanyInfo = await _companyInfoRepository.DeleteAsync(companyInfo);

        return deletedCompanyInfo;
    }
}
