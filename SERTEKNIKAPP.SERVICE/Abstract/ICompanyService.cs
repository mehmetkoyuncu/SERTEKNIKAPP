

using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Utilities.Results;

namespace SERTEKNIKAPP.SERVICE.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult<List<Company>>> GetAllAsync();
        Task<IResult> AddAsync(CompanyRequest companyRequest);
        Task<IResult> UpdateAsync(Company company);

    }
}
