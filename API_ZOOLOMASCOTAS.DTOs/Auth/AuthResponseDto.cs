using API_ZOOLOMASCOTAS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Auth
{
    public class AuthResponseDto
    {
        public Boolean IsSuccess { get; set; }
        public UserDetailResponseDto User { get; set; }
        public string Token { get; set; }
        public string? Message { get; set; }
    }

    public class TokenResponseDto
    {
        public string Token { get; set; }
    }
}
