using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AboutSubRepository : EfRepositoryBase<AboutSub, int, BaseDbContext>, IAboutSubRepository
{
    public AboutSubRepository(BaseDbContext context) : base(context)
    {
    }
}