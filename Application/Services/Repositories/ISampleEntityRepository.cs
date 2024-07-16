using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISampleEntityRepository : IAsyncRepository<SampleEntity, int>, IRepository<SampleEntity, int>
{
}