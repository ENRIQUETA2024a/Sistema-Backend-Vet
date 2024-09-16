using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Clients
{
    public class ClientListResponseDto
    {
        public int id { get; set; }
        public string names { get; set; }
        public string lastnames { get; set; }
        public string photo { get; set; }
        public string document_number { get; set; }
        public string document_type { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public int? idEmployeeCreates { get; set; }
        public int? idEmployeeModifies { get; set; }
        public int totalRegisters { get; set; }
    }
}
