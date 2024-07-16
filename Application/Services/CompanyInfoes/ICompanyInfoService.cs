using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyInfoes;

public interface ICompanyInfoService
{
    Task<CompanyInfo?> GetAsync(
        Expression<Func<CompanyInfo, bool>> predicate,
        Func<IQueryable<CompanyInfo>, IIncludableQueryable<CompanyInfo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyInfo>?> GetListAsync(
        Expression<Func<CompanyInfo, bool>>? predicate = null,
        Func<IQueryable<CompanyInfo>, IOrderedQueryable<CompanyInfo>>? orderBy = null,
        Func<IQueryable<CompanyInfo>, IIncludableQueryable<CompanyInfo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyInfo> AddAsync(CompanyInfo companyInfo);
    Task<CompanyInfo> UpdateAsync(CompanyInfo companyInfo);
    Task<CompanyInfo> DeleteAsync(CompanyInfo companyInfo, bool permanent = false);
}
