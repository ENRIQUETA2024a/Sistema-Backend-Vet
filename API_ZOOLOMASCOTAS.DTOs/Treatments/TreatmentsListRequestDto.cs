using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Treatments
{
    public class TreatmentsListRequestDto
    {
        public int index {  get; set; }
        public int limit { get; set; }
        public int diagnosis_id { get; set; }
    }
}
