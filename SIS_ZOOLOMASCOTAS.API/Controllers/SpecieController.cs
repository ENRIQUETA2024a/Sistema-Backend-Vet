using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Application.User;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using API_ZOOLOMASCOTAS.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/species")]
    [Authorize]
    public class SpecieController : ControllerBase
    {
        private ISpecieApplication _specieApplication;

        public SpecieController(ISpecieApplication specieApplication)
        {
            _specieApplication = specieApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetAll([FromBody] SpecieListRequestDto request)
        {
            try
            {
                var res = await _specieApplication.GetAll(request);
                return Ok(res);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] SpecieCreateRequestDto request)
        {
            try
            {
                var res = await _specieApplication.CreateSpecie(request);
                return Ok(res);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("search")]
        public async Task<ActionResult> SearchSpecie([FromBody] SpecieSearchRequestDto request)
        {
            try
            {
                var res = await _specieApplication.SearchSpecie(request);
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
                var res = await _specieApplication.DeleteSpecie(request);
                return Ok(res);
            }catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
