
using SERTEKNIKAPP.DATA.Abstract;
using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Utilities.Results;
using SERTEKNIKAPP.SERVICE.Abstract;

namespace SERTEKNIKAPP.SERVICE.Concrete
{
    public class SampleClassManager : ISampleClassService
    {
        ISampleClassDal SampleClassDal;
        public SampleClassManager(ISampleClassDal productDal)
        {
            SampleClassDal = productDal;
        }

        public IResult Add(SampleClass product)
        {
            SampleClassDal.Add(product);
            return new SuccessResult("Sample Message ");
        }

        public IResult Update(SampleClass product)
        {
            SampleClassDal.Add(product);
            return new SuccessResult("Sample Message ");
        }

        public IDataResult<List<SampleClass>> GetAll()
        {

            return new SuccessDataResult<List<SampleClass>>(SampleClassDal.GetAll(),"Example Message") ;
        }

        public IDataResult<SampleClass> GetById(int id)
        {
            return new SuccessDataResult<SampleClass>(SampleClassDal.Get(p => p.Id== id)) ;
        }

        public async Task<IResult> AddAsync(SampleClass product)
        {
            await SampleClassDal.AddAsync(product);
            return new SuccessResult("Sample Message");
        }

        public async Task<IResult> UpdateAsync(SampleClass product)
        {
            await SampleClassDal.UpdateAsync(product);
            return new SuccessResult("Sample Message");
        }

        public async Task<IDataResult<List<SampleClass>>> GetAllAsync()
        {
            var result = await SampleClassDal.GetAllAsync();
            return new SuccessDataResult<List<SampleClass>>(result, "Example Message");
        }

        public async Task<IDataResult<SampleClass>> GetByIdAsync(int id)
        {
            var result = await SampleClassDal.GetAsync(p => p.Id == id);
            return new SuccessDataResult<SampleClass>(result);
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = SampleClassDal.GetAll(p => p.Id == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult("Error");
            }
            return new SuccessResult();
        }
        
    }

}
