using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsageAreas;

public interface IUsageAreaService
{
    Task<UsageArea?> GetAsync(
        Expression<Func<UsageArea, bool>> predicate,
        Func<IQueryable<UsageArea>, IIncludableQueryable<UsageArea, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UsageArea>?> GetListAsync(
        Expression<Func<UsageArea, bool>>? predicate = null,
        Func<IQueryable<UsageArea>, IOrderedQueryable<UsageArea>>? orderBy = null,
        Func<IQueryable<UsageArea>, IIncludableQueryable<UsageArea, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UsageArea> AddAsync(UsageArea usageArea);
    Task<UsageArea> UpdateAsync(UsageArea usageArea);
    Task<UsageArea> DeleteAsync(UsageArea usageArea, bool permanent = false);
}
