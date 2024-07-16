using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PortfolioCategoryRepository : EfRepositoryBase<PortfolioCategory, int, BaseDbContext>, IPortfolioCategoryRepository
{
    public PortfolioCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}