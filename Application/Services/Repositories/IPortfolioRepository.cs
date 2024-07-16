using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPortfolioRepository : IAsyncRepository<Portfolio, int>, IRepository<Portfolio, int>
{
}