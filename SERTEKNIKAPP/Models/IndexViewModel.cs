using SERTEKNIKAPP.COMMON.DTO;

namespace SERTEKNIKAPP.Models
{
    public class IndexViewModel
    {
        public List<ServiceSummaryDTO> ServiceSummaryList { get; set; }
        public SliderDTO Slider { get; set; }
        public InfoDTO Info { get; set; }
        public List<ServiceDTO> ServiceList { get; set; }
    }
}
