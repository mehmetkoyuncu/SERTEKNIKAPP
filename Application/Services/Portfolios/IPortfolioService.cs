using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Portfolios;

public interface IPortfolioService
{
    Task<Portfolio?> GetAsync(
        Expression<Func<Portfolio, bool>> predicate,
        Func<IQueryable<Portfolio>, IIncludableQueryable<Portfolio, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Portfolio>?> GetListAsync(
        Expression<Func<Portfolio, bool>>? predicate = null,
        Func<IQueryable<Portfolio>, IOrderedQueryable<Portfolio>>? orderBy = null,
        Func<IQueryable<Portfolio>, IIncludableQueryable<Portfolio, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Portfolio> AddAsync(Portfolio portfolio);
    Task<Portfolio> UpdateAsync(Portfolio portfolio);
    Task<Portfolio> DeleteAsync(Portfolio portfolio, bool permanent = false);
}
