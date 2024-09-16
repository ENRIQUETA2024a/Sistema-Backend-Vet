using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Recetas
{
    public class RecetasCreateRequestDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public string indicaciones { get; set; }
        public int patient_id { get; set; }
    }
}
