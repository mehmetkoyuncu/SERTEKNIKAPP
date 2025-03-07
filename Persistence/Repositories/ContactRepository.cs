using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ContactRepository : EfRepositoryBase<Contact, int, BaseDbContext>, IContactRepository
{
    public ContactRepository(BaseDbContext context) : base(context)
    {
    }
}