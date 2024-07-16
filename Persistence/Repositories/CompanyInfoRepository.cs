using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyInfoRepository : EfRepositoryBase<CompanyInfo, int, BaseDbContext>, ICompanyInfoRepository
{
    public CompanyInfoRepository(BaseDbContext context) : base(context)
    {
    }
}