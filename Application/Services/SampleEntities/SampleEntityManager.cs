using Application.Features.SampleEntities.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SampleEntities;

public class SampleEntityManager : ISampleEntityService
{
    private readonly ISampleEntityRepository _sampleEntityRepository;
    private readonly SampleEntityBusinessRules _sampleEntityBusinessRules;

    public SampleEntityManager(ISampleEntityRepository sampleEntityRepository, SampleEntityBusinessRules sampleEntityBusinessRules)
    {
        _sampleEntityRepository = sampleEntityRepository;
        _sampleEntityBusinessRules = sampleEntityBusinessRules;
    }

    public async Task<SampleEntity?> GetAsync(
        Expression<Func<SampleEntity, bool>> predicate,
        Func<IQueryable<SampleEntity>, IIncludableQueryable<SampleEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SampleEntity? sampleEntity = await _sampleEntityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sampleEntity;
    }

    public async Task<IPaginate<SampleEntity>?> GetListAsync(
        Expression<Func<SampleEntity, bool>>? predicate = null,
        Func<IQueryable<SampleEntity>, IOrderedQueryable<SampleEntity>>? orderBy = null,
        Func<IQueryable<SampleEntity>, IIncludableQueryable<SampleEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SampleEntity> sampleEntityList = await _sampleEntityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sampleEntityList;
    }

    public async Task<SampleEntity> AddAsync(SampleEntity sampleEntity)
    {
        SampleEntity addedSampleEntity = await _sampleEntityRepository.AddAsync(sampleEntity);

        return addedSampleEntity;
    }

    public async Task<SampleEntity> UpdateAsync(SampleEntity sampleEntity)
    {
        SampleEntity updatedSampleEntity = await _sampleEntityRepository.UpdateAsync(sampleEntity);

        return updatedSampleEntity;
    }

    public async Task<SampleEntity> DeleteAsync(SampleEntity sampleEntity, bool permanent = false)
    {
        SampleEntity deletedSampleEntity = await _sampleEntityRepository.DeleteAsync(sampleEntity);

        return deletedSampleEntity;
    }
}
