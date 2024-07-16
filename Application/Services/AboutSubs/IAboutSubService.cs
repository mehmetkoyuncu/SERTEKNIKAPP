using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AboutSubs;

public interface IAboutSubService
{
    Task<AboutSub?> GetAsync(
        Expression<Func<AboutSub, bool>> predicate,
        Func<IQueryable<AboutSub>, IIncludableQueryable<AboutSub, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AboutSub>?> GetListAsync(
        Expression<Func<AboutSub, bool>>? predicate = null,
        Func<IQueryable<AboutSub>, IOrderedQueryable<AboutSub>>? orderBy = null,
        Func<IQueryable<AboutSub>, IIncludableQueryable<AboutSub, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AboutSub> AddAsync(AboutSub aboutSub);
    Task<AboutSub> UpdateAsync(AboutSub aboutSub);
    Task<AboutSub> DeleteAsync(AboutSub aboutSub, bool permanent = false);
}
