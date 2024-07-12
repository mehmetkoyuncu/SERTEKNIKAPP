using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERTEKNIKAPP.COMMON.DTO
{
    public class UsingAreaDTO
    {
        public UsingAreaDTO()
        {
            Items = new List<UsingAreaItemDTO>();
        }
        public string Title { get; set; }
        public List<UsingAreaItemDTO> Items { get; set; }
    }
}
