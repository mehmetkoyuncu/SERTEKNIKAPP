

using SERTEKNIKAPP.DATA.Context;
using SERTEKNIKAPP.DATA.Entity.Concrete;
using SERTEKNIKAPP.DATA.Repository.Abstract;
using SERTEKNIKAPP.DATA.Repository.Concrete.EntityFranework;

namespace SERTEKNIKAPP.DATA.Repository.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, _Context>, ICompanyDal
    {

    }
}
