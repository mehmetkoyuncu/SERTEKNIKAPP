using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IServiceSummaryRepository : IAsyncRepository<ServiceSummary, int>, IRepository<ServiceSummary, int>
{
}