using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Products
{
    public class ProductListResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public string laboratory { get; set; }
        public DateTime expirationDate { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public string category { get; set; }
        public string photo { get; set; }
        public string public_id { get; set; }
        public int totalRecords { get; set; }
    }
}
