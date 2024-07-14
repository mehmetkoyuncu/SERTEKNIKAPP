using SERTEKNIKAPP.DATA.Entity.Abstracts;

namespace SERTEKNIKAPP.DATA.Entity.Concrete
{
    public class Company : IEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string MailAddress { get; set; }
        public string Communication { get; set; }
    }
}
