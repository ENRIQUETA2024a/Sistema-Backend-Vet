using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Categories
{
    public class CategoriesListResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalRecords { get; set; }
    }
}
