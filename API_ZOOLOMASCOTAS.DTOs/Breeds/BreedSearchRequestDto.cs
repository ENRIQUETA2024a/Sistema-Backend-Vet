using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Breeds
{
    public class BreedSearchRequestDto
    {
        public string name { get; set; }
        public int index { get; set; }
        public int limit { get; set; }
    }
}
