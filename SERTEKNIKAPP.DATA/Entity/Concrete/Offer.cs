

using SERTEKNIKAPP.DATA.Entity.Abstracts;

namespace SERTEKNIKAPP.DATA.Entity.Concrete
{
    public class Offer:IEntity //Teklif
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProjectName { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
