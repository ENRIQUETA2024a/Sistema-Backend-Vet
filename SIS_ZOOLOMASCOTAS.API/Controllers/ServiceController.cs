using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/services")]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private IServiceApplication _serviceApplication;

        public ServiceController(IServiceApplication serviceApplication)
        {
            _serviceApplication = serviceApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetServices([FromBody] ServiceListRequestDto request)
        {
            try
            {
                var res = await _serviceApplication.GetServices(request);

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
        public async Task<ActionResult> CreateService([FromBody] ServiceCreateRequestDto request)
        {
            try
            {
                var res = await this._serviceApplication.CreateService(request);
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
        public async Task<ActionResult> DeleteService([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _serviceApplication.DeleteService(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
