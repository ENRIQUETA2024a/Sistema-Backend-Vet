using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost]
        [Route("list")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> GetAll([FromBody] UserListRequestDto request)
        {
            try
            {
                var res = await _userApplication.GetAll(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Create(UserCreateRequestDto request)
        {
            try
            {
                var res = await _userApplication.Create(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> SearchUsersByUsername([FromBody] UserSearchRequestDto request)
        {
            try
            {
                var res = await _userApplication.SearchUsersByUsername(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("delete")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Delete(DeleteDto request)
        {
            try
            {
                var res = await _userApplication.Delete(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
