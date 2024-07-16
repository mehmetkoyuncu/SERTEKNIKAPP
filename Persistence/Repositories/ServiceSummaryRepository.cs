using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ServiceSummaryRepository : EfRepositoryBase<ServiceSummary, int, BaseDbContext>, IServiceSummaryRepository
{
    public ServiceSummaryRepository(BaseDbContext context) : base(context)
    {
    }
}