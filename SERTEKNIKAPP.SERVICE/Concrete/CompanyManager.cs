using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Repository.Abstract;
using SERTEKNIKAPP.DATA.Utilities.Results;
using SERTEKNIKAPP.SERVICE.Abstract;

namespace SERTEKNIKAPP.SERVICE.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal CompanyDal)
        {
            _companyDal = CompanyDal;
        }
        public async Task<IResult> AddAsync(CompanyRequest companyRequest)
        {
            ImageService imageService = new ImageService();
            Company company = new Company
            {
                Communication = companyRequest.Communication,
                LogoUrl = await imageService.UploadAsync(companyRequest.LogoUrl),
                MailAddress = companyRequest.MailAddress,
                Name = companyRequest.Name,
            };
            await _companyDal.AddAsync(company);
            return new SuccessResult("Islem Basarili");
        }


        public async Task<IDataResult<List<Company>>> GetAllAsync()
        {
            var result = await _companyDal.GetAllAsync();
            return new SuccessDataResult<List<Company>>(result);
        }

        public async Task<IResult> UpdateAsync(Company company)
        {
            await _companyDal.UpdateAsync(company);
            return new SuccessResult("Islem Basarili");
        }
    }

}
