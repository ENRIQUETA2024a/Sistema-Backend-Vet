using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Dashboard
{
    public class DashboardInfoResponseDto
    {
        public int clientes {  get; set; }
        public int pacientes { get; set; }
        public int recetas { get; set; }
        public int ventas { get; set; }
    }
}
