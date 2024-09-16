using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Recetas
{
    public class RecetasListResponseDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public string indicaciones { get; set; }
        public string created_at { get; set; }
        public int patient_id { get; set; }
        public string patient { get; set; }
        public int totalRecords { get; set; }
    }
}
