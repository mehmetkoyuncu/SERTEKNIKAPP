using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Abouts;

public interface IAboutService
{
    Task<About?> GetAsync(
        Expression<Func<About, bool>> predicate,
        Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<About>?> GetListAsync(
        Expression<Func<About, bool>>? predicate = null,
        Func<IQueryable<About>, IOrderedQueryable<About>>? orderBy = null,
        Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<About> AddAsync(About about);
    Task<About> UpdateAsync(About about);
    Task<About> DeleteAsync(About about, bool permanent = false);
}
