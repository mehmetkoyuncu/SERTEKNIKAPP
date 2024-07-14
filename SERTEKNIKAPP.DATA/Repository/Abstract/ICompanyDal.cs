

using SERTEKNIKAPP.DATA.Entity.Concrete;

namespace SERTEKNIKAPP.DATA.Repository.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>, IEntityAsyncRepository<Company>
    {

    }
}
