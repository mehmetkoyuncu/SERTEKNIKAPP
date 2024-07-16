using Application.Features.ServiceSummaries.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ServiceSummaries;

public class ServiceSummaryManager : IServiceSummaryService
{
    private readonly IServiceSummaryRepository _serviceSummaryRepository;
    private readonly ServiceSummaryBusinessRules _serviceSummaryBusinessRules;

    public ServiceSummaryManager(IServiceSummaryRepository serviceSummaryRepository, ServiceSummaryBusinessRules serviceSummaryBusinessRules)
    {
        _serviceSummaryRepository = serviceSummaryRepository;
        _serviceSummaryBusinessRules = serviceSummaryBusinessRules;
    }

    public async Task<ServiceSummary?> GetAsync(
        Expression<Func<ServiceSummary, bool>> predicate,
        Func<IQueryable<ServiceSummary>, IIncludableQueryable<ServiceSummary, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ServiceSummary? serviceSummary = await _serviceSummaryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return serviceSummary;
    }

    public async Task<IPaginate<ServiceSummary>?> GetListAsync(
        Expression<Func<ServiceSummary, bool>>? predicate = null,
        Func<IQueryable<ServiceSummary>, IOrderedQueryable<ServiceSummary>>? orderBy = null,
        Func<IQueryable<ServiceSummary>, IIncludableQueryable<ServiceSummary, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ServiceSummary> serviceSummaryList = await _serviceSummaryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return serviceSummaryList;
    }

    public async Task<ServiceSummary> AddAsync(ServiceSummary serviceSummary)
    {
        ServiceSummary addedServiceSummary = await _serviceSummaryRepository.AddAsync(serviceSummary);

        return addedServiceSummary;
    }

    public async Task<ServiceSummary> UpdateAsync(ServiceSummary serviceSummary)
    {
        ServiceSummary updatedServiceSummary = await _serviceSummaryRepository.UpdateAsync(serviceSummary);

        return updatedServiceSummary;
    }

    public async Task<ServiceSummary> DeleteAsync(ServiceSummary serviceSummary, bool permanent = false)
    {
        ServiceSummary deletedServiceSummary = await _serviceSummaryRepository.DeleteAsync(serviceSummary);

        return deletedServiceSummary;
    }
}
