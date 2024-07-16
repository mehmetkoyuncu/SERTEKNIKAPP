using Application.Features.UsageAreas.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UsageAreas;

public class UsageAreaManager : IUsageAreaService
{
    private readonly IUsageAreaRepository _usageAreaRepository;
    private readonly UsageAreaBusinessRules _usageAreaBusinessRules;

    public UsageAreaManager(IUsageAreaRepository usageAreaRepository, UsageAreaBusinessRules usageAreaBusinessRules)
    {
        _usageAreaRepository = usageAreaRepository;
        _usageAreaBusinessRules = usageAreaBusinessRules;
    }

    public async Task<UsageArea?> GetAsync(
        Expression<Func<UsageArea, bool>> predicate,
        Func<IQueryable<UsageArea>, IIncludableQueryable<UsageArea, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UsageArea? usageArea = await _usageAreaRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return usageArea;
    }

    public async Task<IPaginate<UsageArea>?> GetListAsync(
        Expression<Func<UsageArea, bool>>? predicate = null,
        Func<IQueryable<UsageArea>, IOrderedQueryable<UsageArea>>? orderBy = null,
        Func<IQueryable<UsageArea>, IIncludableQueryable<UsageArea, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UsageArea> usageAreaList = await _usageAreaRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return usageAreaList;
    }

    public async Task<UsageArea> AddAsync(UsageArea usageArea)
    {
        UsageArea addedUsageArea = await _usageAreaRepository.AddAsync(usageArea);

        return addedUsageArea;
    }

    public async Task<UsageArea> UpdateAsync(UsageArea usageArea)
    {
        UsageArea updatedUsageArea = await _usageAreaRepository.UpdateAsync(usageArea);

        return updatedUsageArea;
    }

    public async Task<UsageArea> DeleteAsync(UsageArea usageArea, bool permanent = false)
    {
        UsageArea deletedUsageArea = await _usageAreaRepository.DeleteAsync(usageArea);

        return deletedUsageArea;
    }
}
