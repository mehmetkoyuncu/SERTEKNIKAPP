using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SampleEntityRepository : EfRepositoryBase<SampleEntity, int, BaseDbContext>, ISampleEntityRepository
{
    public SampleEntityRepository(BaseDbContext context) : base(context)
    {
    }
}