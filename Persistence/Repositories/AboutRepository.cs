using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AboutRepository : EfRepositoryBase<About, int, BaseDbContext>, IAboutRepository
{
    public AboutRepository(BaseDbContext context) : base(context)
    {
    }
}