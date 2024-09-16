using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Products
{
    public class ProductCreateRequestDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public string laboratory { get; set; }
        public DateTime expirationDate { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public DateTime? registrationDate { get; set; }
        public int? idEmployeeCreates { get; set; }
        public int? idEmployeeModifies { get; set; }
        public IFormFile? photo { get; set; }
        public string? public_id { get; set; }
        public string? uri_photo { get; set; }
    }
 }
