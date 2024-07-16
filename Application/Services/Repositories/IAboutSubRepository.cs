using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAboutSubRepository : IAsyncRepository<AboutSub, int>, IRepository<AboutSub, int>
{
}