using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUsageAreaRepository : IAsyncRepository<UsageArea, int>, IRepository<UsageArea, int>
{
}