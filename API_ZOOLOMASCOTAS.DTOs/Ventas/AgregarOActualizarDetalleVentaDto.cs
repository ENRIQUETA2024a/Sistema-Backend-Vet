using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Ventas
{
    public class AgregarOActualizarDetalleVentaDto
    {
        public int id_venta { get; set; }
        public int? id_cliente { get; set; }
        public int? id_producto { get; set; }
        public int? id_servicio { get; set; }
        public int cantidad { get; set; }
    }
}
