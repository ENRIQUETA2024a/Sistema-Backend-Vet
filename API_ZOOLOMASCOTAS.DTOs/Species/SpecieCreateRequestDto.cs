using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Species
{
    public class SpecieCreateRequestDto
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string scientificName { get; set; }

    }
}
