using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Ventas
{
    public class ListarVentasResponseDto
    {
        public int id_venta { get; set; }
        public string client { get; set; }
        public DateTime fecha_venta { get; set; }
        public decimal total_venta { get; set; }
        public int totalRegisters { get; set; }
    }

}
