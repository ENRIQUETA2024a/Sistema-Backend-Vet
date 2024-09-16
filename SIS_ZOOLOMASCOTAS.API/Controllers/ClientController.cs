using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private IClientApplication _clientApplication;

        public ClientController(IClientApplication clientApplication)
        {
            _clientApplication = clientApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetClients([FromBody] ClientListRequestDto request)
        {
            try
            {
                var res = await _clientApplication.GetClients(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateClient([FromForm] ClientCreateRequestDto request)
        {
            try
            {
               
                var res = await this._clientApplication.CreateClient(request);
                
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<ActionResult> SearchClient([FromBody] ClientSearchRequestDto request)
        {
            try
            {
                var res = await _clientApplication.SearchClient(request);
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
        public async Task<ActionResult> DeleteClient([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _clientApplication.DeleteClient(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
