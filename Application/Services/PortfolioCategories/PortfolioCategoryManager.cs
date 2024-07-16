using Application.Features.PortfolioCategories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PortfolioCategories;

public class PortfolioCategoryManager : IPortfolioCategoryService
{
    private readonly IPortfolioCategoryRepository _portfolioCategoryRepository;
    private readonly PortfolioCategoryBusinessRules _portfolioCategoryBusinessRules;

    public PortfolioCategoryManager(IPortfolioCategoryRepository portfolioCategoryRepository, PortfolioCategoryBusinessRules portfolioCategoryBusinessRules)
    {
        _portfolioCategoryRepository = portfolioCategoryRepository;
        _portfolioCategoryBusinessRules = portfolioCategoryBusinessRules;
    }

    public async Task<PortfolioCategory?> GetAsync(
        Expression<Func<PortfolioCategory, bool>> predicate,
        Func<IQueryable<PortfolioCategory>, IIncludableQueryable<PortfolioCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PortfolioCategory? portfolioCategory = await _portfolioCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return portfolioCategory;
    }

    public async Task<IPaginate<PortfolioCategory>?> GetListAsync(
        Expression<Func<PortfolioCategory, bool>>? predicate = null,
        Func<IQueryable<PortfolioCategory>, IOrderedQueryable<PortfolioCategory>>? orderBy = null,
        Func<IQueryable<PortfolioCategory>, IIncludableQueryable<PortfolioCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PortfolioCategory> portfolioCategoryList = await _portfolioCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return portfolioCategoryList;
    }

    public async Task<PortfolioCategory> AddAsync(PortfolioCategory portfolioCategory)
    {
        PortfolioCategory addedPortfolioCategory = await _portfolioCategoryRepository.AddAsync(portfolioCategory);

        return addedPortfolioCategory;
    }

    public async Task<PortfolioCategory> UpdateAsync(PortfolioCategory portfolioCategory)
    {
        PortfolioCategory updatedPortfolioCategory = await _portfolioCategoryRepository.UpdateAsync(portfolioCategory);

        return updatedPortfolioCategory;
    }

    public async Task<PortfolioCategory> DeleteAsync(PortfolioCategory portfolioCategory, bool permanent = false)
    {
        PortfolioCategory deletedPortfolioCategory = await _portfolioCategoryRepository.DeleteAsync(portfolioCategory);

        return deletedPortfolioCategory;
    }
}
