using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Treatments
{
    public class TreatmentsCreateRequestDto
    {

        public int id { get; set; }
        public string detail { get; set; }
        public int diagnosis_id { get; set; }
        public List<ProductsTreatmentCreateRequestDto> products { get; set; }
    }
}
