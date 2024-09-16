using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Application.Client;
using API_ZOOLOMASCOTAS.Application.Consults;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Consults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/consults")]
    [Authorize]
    public class ConsultController : ControllerBase
    {
        private readonly IConsultApplication consultApplication;

        public ConsultController(IConsultApplication consultApplication)
        {
            this.consultApplication = consultApplication;
        }
        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetConsults([FromBody] ConsultListRequestDto request)
        {
            try
            {
                var res = await this.consultApplication.GetConsults(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateConsult([FromBody] ConsultCreateRequestDto request)
        {
            try
            {
                var res = await this.consultApplication.CreateConsult(request);
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
        public async Task<ActionResult> DeleteConsult([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this.consultApplication.DeleteConsult(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
