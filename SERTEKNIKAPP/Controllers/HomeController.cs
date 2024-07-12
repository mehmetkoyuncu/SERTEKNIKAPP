using Microsoft.AspNetCore.Mvc;
using SERTEKNIKAPP.COMMON.DTO;
using SERTEKNIKAPP.Models;
using System.Diagnostics;

namespace SERTEKNIKAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CompanyInfoDTO companyInfo = new CompanyInfoDTO()
            {
                LogoUrl = "/img/york-1.png",
                Mail = "info@yorktr.com",
                Phone1 = "0 (850) 250 96 75",
                Phone2 = "0 (216) 636 53 00"
            };
            ViewBag.Company = companyInfo;
            IndexViewModel vm = new IndexViewModel()
            {
                ServiceSummaryList = new List<ServiceSummaryDTO> {
                   new ServiceSummaryDTO()
                   {
                       Title = "PROJELENDİRME",
                       Content = "Mevcut yapınıza en uygun projelendirme hizmeti sunuyoruz.",
                       Url = "mailto:info@yorktr.com",
                       IsSelected=false
                   },
                    new ServiceSummaryDTO()
                   {
                       Title = "CİHAZ TEMİNİ",
                       Content = "Projenize uygun bütcenize göre en ideal marka ile cihaz temin ediyoruz.",
                       Url = "mailto:info@yorktr.com",
                       IsSelected=false
                   },
                     new ServiceSummaryDTO()
                   {
                       Title = "MONTAJ",
                       Content = "Seçilen cihazların projenize uygun montaj işlemini uyguluyoruz.",
                       Url = "mailto:info@yorktr.com",
                       IsSelected=true
                   },
               },
                Slider = new SliderDTO()
                {
                    VideoUrl = "/videos/istockphoto-1310797404-640_adpp_is.mp4",
                    ButtonText = "TEKLİF İSTE",
                    Title = "YORK TÜRKİYE",
                    Content = "YORK Endüstriyel VRF Dünyasına Hoş Geldiniz",
                    SmallText = "Teklif İstekleriniz İçin Tıklayınız",
                    ButtonUrl = "mailto:info@yorktr.com"

                },
                Info = new InfoDTO()
                {
                    Title = "YORK VRF Klima Satış ve Servis Merkezi",
                    SmallText = "BİZİMLE İLETİŞİME GEÇİN",
                    Content = "Alanında uzman satış ekipleriyle aynı gün ücretsiz keşif ile ihtiyacınız olan klimayı belirlemekte, en iyi fiyat garantili satış yapmakta, kullanım sırasında da bakım, onarım, yedek parça ve aksesuar ihtiyaçlarınızı hızlı ve sorunsuz şekilde karşılamaktadır.",
                    URL = "/videos/york-vrf.mp4"
                },
                ServiceList = new List<ServiceDTO>()
                {
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-tag",
                        Title="Danışmanlık",
                        Content="Mekanik tesisat uygulamalarında, mevcut sistemlerin kontrollerinin yapılarak iyileştirme için gerekli proje danışmanlık desteğinin sağlıyoruz."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-tent",
                        Title="Projelendirme",
                        Content="Klimanın takılacağı mekâna en uygun kapasitenin seçimi, teknik gerekliliklerin ve tüketici beklentilerinin tam anlamıyla anlaşılması için ücretsiz keşif hizmeti sunulmaktadır."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-rocket",
                        Title="Keşif",
                        Content="Konusunda uzman mühendis kadromuzla güncel hesap ve tasarım yazılımları desteğiyle mekanik tesisat projelerini müşterilerimizin ihtiyaçlarına göre projelendirmekteyiz"
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-cart-shopping",
                        Title="Cihaz Temini",
                        Content="Projelendirme hizmeti sonrası sizin için en uygun cihaz seçimi ve fiyatlandırılması."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-regular fa-share-from-square",
                        Title="Montaj",
                        Content="Uzman kadromuzla siz değerli müşterilerimizin cihaz montajlarının yapılması."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-gear",
                        Title="Teknik Destek",
                        Content="Montaj sonrası düzenli bakım ve arızalarınıza hızlı çözüm üretmek için varız."
                    }
                }

            };
            return View(vm);
        }
        //public IActionResult GetVideoSlider()
        //{

        //}

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            CompanyInfoDTO companyInfo = new CompanyInfoDTO()
            {
                LogoUrl = "/img/york-1.png",
                Mail = "info@yorktr.com",
                Phone1 = "0 (850) 250 96 75",
                Phone2 = "0 (216) 636 53 00"
            };
            ViewBag.Company = companyInfo;

            AboutDTO about = new AboutDTO()
            {
                Title = "YORK VRF Klima Satış ve Servis Merkezi",
                SmallText = "Alanında uzman satış ekipleriyle aynı gün ücretsiz keşif ile ihtiyacınız olan klimayı belirlemekte, en iyi fiyat garantili satış yapmakta, kullanım sırasında da bakım, onarım, yedek parça ve aksesuar ihtiyaçlarınızı hızlı ve sorunsuz şekilde karşılamaktadır.",
                HTMLContent= "\t<h1>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tHizmet Politikamız\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</h1>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<p>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tDünyada ve Türkiye’de en çok kullanılan klima markasını müşterilerimize sunmak, hızlı ve çözüm odaklı satış öncesi ve sonrası destek vermek, garantili teslimat ve uygun ödeme seçenekleri sağlamak hizmet politikamızdır.\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</p>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<h1>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tKalite Anlayışımız\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</h1>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<p>\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\tHer daim en yeniyi takip etmek ve ileri teknoloji klimaları müşterilerimizle buluşturmak, kadromuzun bilgi ve becerilerini geliştirerek müşteri ihtiyaçlarını en iyi şekilde karşılamak, gelişmek ve yenilenmek kalite anlayışımızdır.\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</p>",
                ImageURL= "/img/161ee7ec2237ff_thump.jpg"
            };

            return View(about);
        }
		public IActionResult Services()
        {
            var serviceList = new List<ServiceDTO>()
                {
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-tag",
                        Title="Danışmanlık",
                        Content="Mekanik tesisat uygulamalarında, mevcut sistemlerin kontrollerinin yapılarak iyileştirme için gerekli proje danışmanlık desteğinin sağlıyoruz."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-tent",
                        Title="Projelendirme",
                        Content="Klimanın takılacağı mekâna en uygun kapasitenin seçimi, teknik gerekliliklerin ve tüketici beklentilerinin tam anlamıyla anlaşılması için ücretsiz keşif hizmeti sunulmaktadır."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-rocket",
                        Title="Keşif",
                        Content="Konusunda uzman mühendis kadromuzla güncel hesap ve tasarım yazılımları desteğiyle mekanik tesisat projelerini müşterilerimizin ihtiyaçlarına göre projelendirmekteyiz"
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-cart-shopping",
                        Title="Cihaz Temini",
                        Content="Projelendirme hizmeti sonrası sizin için en uygun cihaz seçimi ve fiyatlandırılması."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-regular fa-share-from-square",
                        Title="Montaj",
                        Content="Uzman kadromuzla siz değerli müşterilerimizin cihaz montajlarının yapılması."
                    },
                    new ServiceDTO()
                    {
                        Icon="fa-solid fa-gear",
                        Title="Teknik Destek",
                        Content="Montaj sonrası düzenli bakım ve arızalarınıza hızlı çözüm üretmek için varız."
                    }
                };


            CompanyInfoDTO companyInfo = new CompanyInfoDTO()
			{
				LogoUrl = "/img/york-1.png",
				Mail = "info@yorktr.com",
				Phone1 = "0 (850) 250 96 75",
				Phone2 = "0 (216) 636 53 00"
			};
			ViewBag.Company = companyInfo;
			return View(serviceList);
		}

        public IActionResult UsingArea()
        {
            CompanyInfoDTO companyInfo = new CompanyInfoDTO()
            {
                LogoUrl = "/img/york-1.png",
                Mail = "info@yorktr.com",
                Phone1 = "0 (850) 250 96 75",
                Phone2 = "0 (216) 636 53 00"
            };
            ViewBag.Company = companyInfo;
            var items = new List<UsingAreaItemDTO>()
                {
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-tag",
                        Title="Danışmanlık",
                        Content="Mekanik tesisat uygulamalarında, mevcut sistemlerin kontrollerinin yapılarak iyileştirme için gerekli proje danışmanlık desteğinin sağlıyoruz."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-tent",
                        Title="Projelendirme",
                        Content="Klimanın takılacağı mekâna en uygun kapasitenin seçimi, teknik gerekliliklerin ve tüketici beklentilerinin tam anlamıyla anlaşılması için ücretsiz keşif hizmeti sunulmaktadır."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-rocket",
                        Title="Keşif",
                        Content="Konusunda uzman mühendis kadromuzla güncel hesap ve tasarım yazılımları desteğiyle mekanik tesisat projelerini müşterilerimizin ihtiyaçlarına göre projelendirmekteyiz"
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-cart-shopping",
                        Title="Cihaz Temini",
                        Content="Projelendirme hizmeti sonrası sizin için en uygun cihaz seçimi ve fiyatlandırılması."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-regular fa-share-from-square",
                        Title="Montaj",
                        Content="Uzman kadromuzla siz değerli müşterilerimizin cihaz montajlarının yapılması."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-gear",
                        Title="Teknik Destek",
                        Content="Montaj sonrası düzenli bakım ve arızalarınıza hızlı çözüm üretmek için varız."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-tag",
                        Title="Danışmanlık",
                        Content="Mekanik tesisat uygulamalarında, mevcut sistemlerin kontrollerinin yapılarak iyileştirme için gerekli proje danışmanlık desteğinin sağlıyoruz."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-tent",
                        Title="Projelendirme",
                        Content="Klimanın takılacağı mekâna en uygun kapasitenin seçimi, teknik gerekliliklerin ve tüketici beklentilerinin tam anlamıyla anlaşılması için ücretsiz keşif hizmeti sunulmaktadır."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-rocket",
                        Title="Keşif",
                        Content="Konusunda uzman mühendis kadromuzla güncel hesap ve tasarım yazılımları desteğiyle mekanik tesisat projelerini müşterilerimizin ihtiyaçlarına göre projelendirmekteyiz"
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-cart-shopping",
                        Title="Cihaz Temini",
                        Content="Projelendirme hizmeti sonrası sizin için en uygun cihaz seçimi ve fiyatlandırılması."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-regular fa-share-from-square",
                        Title="Montaj",
                        Content="Uzman kadromuzla siz değerli müşterilerimizin cihaz montajlarının yapılması."
                    },
                    new UsingAreaItemDTO()
                    {
                        Icon="fa-solid fa-gear",
                        Title="Teknik Destek",
                        Content="Montaj sonrası düzenli bakım ve arızalarınıza hızlı çözüm üretmek için varız."
                    }
                };

            var area = new UsingAreaDTO()
            {
                Title = "Vrf Klima Uygulama Alanları",
                Items = items
            };
            return View(area);
        }
        public IActionResult Portfoy()
        {
            CompanyInfoDTO companyInfo = new CompanyInfoDTO()
            {
                LogoUrl = "/img/york-1.png",
                Mail = "info@yorktr.com",
                Phone1 = "0 (850) 250 96 75",
                Phone2 = "0 (216) 636 53 00"
            };
            ViewBag.Company = companyInfo;
            return View();
        }

			[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
