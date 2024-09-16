using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
   
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserApplication _userApplication;

        public AuthController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            try
            {
                var res = await _userApplication.Login(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
