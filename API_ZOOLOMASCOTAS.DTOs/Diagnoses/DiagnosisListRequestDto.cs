﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Diagnoses
{
    public class DiagnosisListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 10;
        public int consult_id { get; set; }
    }
}
