using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Recetas
{
    public class RecetasListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; }
        public int patient_id { get; set; }
    }
}
