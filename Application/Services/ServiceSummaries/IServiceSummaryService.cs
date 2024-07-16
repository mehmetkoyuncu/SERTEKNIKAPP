using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ServiceSummaries;

public interface IServiceSummaryService
{
    Task<ServiceSummary?> GetAsync(
        Expression<Func<ServiceSummary, bool>> predicate,
        Func<IQueryable<ServiceSummary>, IIncludableQueryable<ServiceSummary, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ServiceSummary>?> GetListAsync(
        Expression<Func<ServiceSummary, bool>>? predicate = null,
        Func<IQueryable<ServiceSummary>, IOrderedQueryable<ServiceSummary>>? orderBy = null,
        Func<IQueryable<ServiceSummary>, IIncludableQueryable<ServiceSummary, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ServiceSummary> AddAsync(ServiceSummary serviceSummary);
    Task<ServiceSummary> UpdateAsync(ServiceSummary serviceSummary);
    Task<ServiceSummary> DeleteAsync(ServiceSummary serviceSummary, bool permanent = false);
}
