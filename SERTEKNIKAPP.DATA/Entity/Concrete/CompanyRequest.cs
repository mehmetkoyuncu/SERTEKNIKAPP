using Microsoft.AspNetCore.Http;

namespace SERTEKNIKAPP.DATA.Entity.Concrete
{
    public class CompanyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile LogoUrl { get; set; }
        public string MailAddress { get; set; }
        public string Communication { get; set; }
    }
}
