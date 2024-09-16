using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.User
{
    public class UserListResponseDTO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string employee_names { get; set; }
        public string role_name { get; set; }
        public int totalRegisters { get; set; }
    }
}
