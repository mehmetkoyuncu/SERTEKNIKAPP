
using SERTEKNIKAPP.DATA.Abstract;
using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Repository.Abstract;
using SERTEKNIKAPP.DATA.Utilities.Results;
using SERTEKNIKAPP.SERVICE.Abstract;

namespace SERTEKNIKAPP.SERVICE.Concrete
{
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;
        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }
        public async Task<IResult> AddAsync(Offer offer)
        {
            await _offerDal.AddAsync(offer);
            return new SuccessResult("Islem Basarili");
        }


        public async Task<IDataResult<List<Offer>>> GetAllAsync()
        {
            var result = await _offerDal.GetAllAsync();
            return new SuccessDataResult<List<Offer>>(result);
        }

        public async Task<IDataResult<Offer>> GetByIdAsync(int id)
        {
            var result = await _offerDal.GetAsync(p => p.Id == id);
            return new SuccessDataResult<Offer>(result);
        }
    }

}
