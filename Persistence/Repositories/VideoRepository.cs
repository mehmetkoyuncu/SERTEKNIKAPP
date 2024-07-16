using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VideoRepository : EfRepositoryBase<Video, int, BaseDbContext>, IVideoRepository
{
    public VideoRepository(BaseDbContext context) : base(context)
    {
    }
}