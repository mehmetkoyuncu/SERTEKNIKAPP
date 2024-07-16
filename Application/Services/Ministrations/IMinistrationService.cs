using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ministrations;

public interface IMinistrationService
{
    Task<Ministration?> GetAsync(
        Expression<Func<Ministration, bool>> predicate,
        Func<IQueryable<Ministration>, IIncludableQueryable<Ministration, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Ministration>?> GetListAsync(
        Expression<Func<Ministration, bool>>? predicate = null,
        Func<IQueryable<Ministration>, IOrderedQueryable<Ministration>>? orderBy = null,
        Func<IQueryable<Ministration>, IIncludableQueryable<Ministration, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Ministration> AddAsync(Ministration ministration);
    Task<Ministration> UpdateAsync(Ministration ministration);
    Task<Ministration> DeleteAsync(Ministration ministration, bool permanent = false);
}
