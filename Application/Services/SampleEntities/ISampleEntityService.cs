using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SampleEntities;

public interface ISampleEntityService
{
    Task<SampleEntity?> GetAsync(
        Expression<Func<SampleEntity, bool>> predicate,
        Func<IQueryable<SampleEntity>, IIncludableQueryable<SampleEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SampleEntity>?> GetListAsync(
        Expression<Func<SampleEntity, bool>>? predicate = null,
        Func<IQueryable<SampleEntity>, IOrderedQueryable<SampleEntity>>? orderBy = null,
        Func<IQueryable<SampleEntity>, IIncludableQueryable<SampleEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SampleEntity> AddAsync(SampleEntity sampleEntity);
    Task<SampleEntity> UpdateAsync(SampleEntity sampleEntity);
    Task<SampleEntity> DeleteAsync(SampleEntity sampleEntity, bool permanent = false);
}
