using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UsageAreaRepository : EfRepositoryBase<UsageArea, int, BaseDbContext>, IUsageAreaRepository
{
    public UsageAreaRepository(BaseDbContext context) : base(context)
    {
    }
}