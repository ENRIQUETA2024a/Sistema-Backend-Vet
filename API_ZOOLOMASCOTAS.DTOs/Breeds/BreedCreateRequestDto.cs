using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Breeds
{
    public class BreedCreateRequestDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int specie_id { get; set; }
    }
}
