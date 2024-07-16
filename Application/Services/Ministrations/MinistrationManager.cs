using Application.Features.Ministrations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ministrations;

public class MinistrationManager : IMinistrationService
{
    private readonly IMinistrationRepository _ministrationRepository;
    private readonly MinistrationBusinessRules _ministrationBusinessRules;

    public MinistrationManager(IMinistrationRepository ministrationRepository, MinistrationBusinessRules ministrationBusinessRules)
    {
        _ministrationRepository = ministrationRepository;
        _ministrationBusinessRules = ministrationBusinessRules;
    }

    public async Task<Ministration?> GetAsync(
        Expression<Func<Ministration, bool>> predicate,
        Func<IQueryable<Ministration>, IIncludableQueryable<Ministration, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ministration? ministration = await _ministrationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ministration;
    }

    public async Task<IPaginate<Ministration>?> GetListAsync(
        Expression<Func<Ministration, bool>>? predicate = null,
        Func<IQueryable<Ministration>, IOrderedQueryable<Ministration>>? orderBy = null,
        Func<IQueryable<Ministration>, IIncludableQueryable<Ministration, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ministration> ministrationList = await _ministrationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ministrationList;
    }

    public async Task<Ministration> AddAsync(Ministration ministration)
    {
        Ministration addedMinistration = await _ministrationRepository.AddAsync(ministration);

        return addedMinistration;
    }

    public async Task<Ministration> UpdateAsync(Ministration ministration)
    {
        Ministration updatedMinistration = await _ministrationRepository.UpdateAsync(ministration);

        return updatedMinistration;
    }

    public async Task<Ministration> DeleteAsync(Ministration ministration, bool permanent = false)
    {
        Ministration deletedMinistration = await _ministrationRepository.DeleteAsync(ministration);

        return deletedMinistration;
    }
}
