

using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Utilities.Results;

namespace SERTEKNIKAPP.SERVICE.Abstract
{
    public interface ISampleClassService
    {
        IDataResult<List<SampleClass>> GetAll();
        IResult Add(SampleClass product);
        IResult Update(SampleClass product);
        IDataResult<SampleClass> GetById(int id);
        Task<IDataResult<List<SampleClass>>> GetAllAsync();
        Task<IResult> AddAsync(SampleClass product);
        Task<IResult> UpdateAsync(SampleClass product);
        Task<IDataResult<SampleClass>> GetByIdAsync(int id);
    }
}
