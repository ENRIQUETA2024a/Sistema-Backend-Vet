using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Roles
{
    public class RolesListResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalRegisters { get; set; }
    }
}
