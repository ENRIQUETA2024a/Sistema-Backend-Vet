using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Patients
{
    public class PatientCreateRequestDto
    {
        public int id { get; set; }
        public string names { get; set; }
        public IFormFile? photo { get; set; }
        public DateTime birthday { get; set; }
        public string age { get; set; }
        public string sex { get; set; }
        public string color { get; set; }
        public string fur { get; set; }
        public string particularity { get; set; }
        public string allergy { get; set; }
        public int breed_id { get; set; }
        public int client_id { get; set; }
        public string? uri_photo { get; set; }
        public string? public_id { get; set; }
    }
}
