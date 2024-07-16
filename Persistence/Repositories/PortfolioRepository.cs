using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PortfolioRepository : EfRepositoryBase<Portfolio, int, BaseDbContext>, IPortfolioRepository
{
    public PortfolioRepository(BaseDbContext context) : base(context)
    {
    }
}