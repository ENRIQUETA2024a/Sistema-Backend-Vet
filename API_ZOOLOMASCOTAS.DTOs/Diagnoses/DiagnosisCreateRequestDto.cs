using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Diagnoses
{
    public class DiagnosisCreateRequestDto
    {
        public int id { get; set; }
        public string detail { get; set; }
        public DateTime date_diagnosis { get; set; }
        public int consult_id { get; set; }
    }
}
