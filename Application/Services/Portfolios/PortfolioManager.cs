using Application.Features.Portfolios.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Portfolios;

public class PortfolioManager : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly PortfolioBusinessRules _portfolioBusinessRules;

    public PortfolioManager(IPortfolioRepository portfolioRepository, PortfolioBusinessRules portfolioBusinessRules)
    {
        _portfolioRepository = portfolioRepository;
        _portfolioBusinessRules = portfolioBusinessRules;
    }

    public async Task<Portfolio?> GetAsync(
        Expression<Func<Portfolio, bool>> predicate,
        Func<IQueryable<Portfolio>, IIncludableQueryable<Portfolio, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Portfolio? portfolio = await _portfolioRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return portfolio;
    }

    public async Task<IPaginate<Portfolio>?> GetListAsync(
        Expression<Func<Portfolio, bool>>? predicate = null,
        Func<IQueryable<Portfolio>, IOrderedQueryable<Portfolio>>? orderBy = null,
        Func<IQueryable<Portfolio>, IIncludableQueryable<Portfolio, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Portfolio> portfolioList = await _portfolioRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return portfolioList;
    }

    public async Task<Portfolio> AddAsync(Portfolio portfolio)
    {
        Portfolio addedPortfolio = await _portfolioRepository.AddAsync(portfolio);

        return addedPortfolio;
    }

    public async Task<Portfolio> UpdateAsync(Portfolio portfolio)
    {
        Portfolio updatedPortfolio = await _portfolioRepository.UpdateAsync(portfolio);

        return updatedPortfolio;
    }

    public async Task<Portfolio> DeleteAsync(Portfolio portfolio, bool permanent = false)
    {
        Portfolio deletedPortfolio = await _portfolioRepository.DeleteAsync(portfolio);

        return deletedPortfolio;
    }
}
