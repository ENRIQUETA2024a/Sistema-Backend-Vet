using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Clients
{
    public class ClientCreateRequestDto
    {
        public int id { get; set; }
        public string names { get; set; }
        public string lastnames { get; set; }
        public IFormFile? photo { get; set; }
        public string document_number { get; set; }
        public string document_type { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? email { get; set; }
        public DateTime? registrationDate { get; set; }
        public int? idEmployeeCreates { get; set; } 
        public int? idEmployeeModifies { get; set; }
        public int? EmployeeId { get; set; }
        public string? uri_photo { get; set; }
        public string? public_id { get; set; }
    }
}
