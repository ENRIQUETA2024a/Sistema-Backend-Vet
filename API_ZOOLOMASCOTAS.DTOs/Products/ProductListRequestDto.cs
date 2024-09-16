using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Products
{
    public class ProductListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 5;
    }
}
