using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Ventas
{
    public class VentaListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 5;
    }
}
