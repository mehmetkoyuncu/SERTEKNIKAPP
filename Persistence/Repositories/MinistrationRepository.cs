using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MinistrationRepository : EfRepositoryBase<Ministration, int, BaseDbContext>, IMinistrationRepository
{
    public MinistrationRepository(BaseDbContext context) : base(context)
    {
    }
}