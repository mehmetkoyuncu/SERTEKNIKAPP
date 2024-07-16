using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyInfoRepository : IAsyncRepository<CompanyInfo, int>, IRepository<CompanyInfo, int>
{
}