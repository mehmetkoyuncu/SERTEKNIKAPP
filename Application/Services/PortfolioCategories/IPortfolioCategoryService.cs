using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PortfolioCategories;

public interface IPortfolioCategoryService
{
    Task<PortfolioCategory?> GetAsync(
        Expression<Func<PortfolioCategory, bool>> predicate,
        Func<IQueryable<PortfolioCategory>, IIncludableQueryable<PortfolioCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PortfolioCategory>?> GetListAsync(
        Expression<Func<PortfolioCategory, bool>>? predicate = null,
        Func<IQueryable<PortfolioCategory>, IOrderedQueryable<PortfolioCategory>>? orderBy = null,
        Func<IQueryable<PortfolioCategory>, IIncludableQueryable<PortfolioCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PortfolioCategory> AddAsync(PortfolioCategory portfolioCategory);
    Task<PortfolioCategory> UpdateAsync(PortfolioCategory portfolioCategory);
    Task<PortfolioCategory> DeleteAsync(PortfolioCategory portfolioCategory, bool permanent = false);
}
