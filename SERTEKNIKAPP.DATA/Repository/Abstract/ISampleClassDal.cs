using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Repository.Abstract;

namespace SERTEKNIKAPP.DATA.Abstract
{
    public interface ISampleClassDal:IEntityRepository<SampleClass>,IEntityAsyncRepository<SampleClass>
    {

    }
}
