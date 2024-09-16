using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Clients
{
    public class ClientSearchRequestDto
    {
        public string search { get; set; }
        public int index { get; set; }
        public int limit { get; set; }
    }
}
