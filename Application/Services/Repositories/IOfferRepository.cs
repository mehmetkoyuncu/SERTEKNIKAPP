using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOfferRepository : IAsyncRepository<Offer, int>, IRepository<Offer, int>
{
}