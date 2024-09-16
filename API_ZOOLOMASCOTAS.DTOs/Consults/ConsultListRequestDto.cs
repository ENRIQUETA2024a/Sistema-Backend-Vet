using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Consults
{
    public class ConsultListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int patient_id { get; set; }
    }
}
