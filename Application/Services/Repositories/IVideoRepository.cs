using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IVideoRepository : IAsyncRepository<Video, int>, IRepository<Video, int>
{
}