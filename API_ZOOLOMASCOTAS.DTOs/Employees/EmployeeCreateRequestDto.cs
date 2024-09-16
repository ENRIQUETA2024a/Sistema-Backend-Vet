using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Employees
{
    public class EmployeeCreateRequestDto
    {
        public int id { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }
        public string names { get; set; }
        public string lastNames { get; set; }
        public DateTime dateBirth { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string cargo { get; set; }
    }
}
