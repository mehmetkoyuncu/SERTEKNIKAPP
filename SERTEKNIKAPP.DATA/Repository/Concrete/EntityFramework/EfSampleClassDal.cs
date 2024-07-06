
using SERTEKNIKAPP.DATA.Abstract;
using SERTEKNIKAPP.DATA.Context;
using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Repository.Concrete.EntityFranework;

namespace SERTEKNIKAPP.DATA.Concrete.EntityFranework
{
    public class EfSampleClassDal : EfEntityRepositoryBase<SampleClass, _Context>, ISampleClassDal
    {
       
    }
}
