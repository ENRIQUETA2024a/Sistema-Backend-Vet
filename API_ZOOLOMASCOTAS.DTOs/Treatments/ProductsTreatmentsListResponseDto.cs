﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Treatments
{

    public class ProductsTreatmentsListResponseDto
    {
        public int id { get; set; }
        public int treatment_id { get; set; }
        public int product_id { get; set; }
        public string name { get; set; }
        public int totalRecords { get; set; }
    }
}
