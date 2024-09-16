using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Categories;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    [Authorize]
    public class RolController : ControllerBase
    {
        private readonly IRolApplication rolApplication;

        public RolController(IRolApplication rolApplication)
        {
            this.rolApplication = rolApplication;
        }

        [HttpPost]
        [Route("list")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult> GetAll([FromBody] RolesListRequestDto request)
        {
            try
            {
                var res = await rolApplication.GetRoles(request);
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
        public async Task<ActionResult> Create([FromBody] RolCreateRequestDto request)
        {
            try
            {
                var res = await rolApplication.CreateRoles(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await rolApplication.DeleteRoles(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

