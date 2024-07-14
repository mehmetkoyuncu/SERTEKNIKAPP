using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERTEKNIKAPP.COMMON.DTO
{
    public class PortfoyCategoryDTO
    {
        public PortfoyCategoryDTO()
        {
            PortfoyList = new List<PortfoyDTO>();
        }
        public string Code { get; set; }
        public string Text { get; set; }
        public List<PortfoyDTO> PortfoyList { get; set; }
    }
}
