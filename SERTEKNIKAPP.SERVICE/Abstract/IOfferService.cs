

using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Utilities.Results;

namespace SERTEKNIKAPP.SERVICE.Abstract
{
    public interface IOfferService
    {
        Task<IDataResult<List<Offer>>> GetAllAsync();
        Task<IResult> AddAsync(Offer product);
        Task<IDataResult<Offer>> GetByIdAsync(int id);
    }
}
