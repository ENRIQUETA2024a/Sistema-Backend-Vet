using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Application.Breed;
using API_ZOOLOMASCOTAS.Application.Specie;
using API_ZOOLOMASCOTAS.DTOs.Breeds;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/breeds")]
    [Authorize]
    public class BreedController : ControllerBase
    {
        private IBreedApplication _breedApplication;

        public BreedController(IBreedApplication breedApplication)
        {
            _breedApplication = breedApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetBreeds([FromBody] BreedListRequestDto request)
        {
            try
            {
                var res = await _breedApplication.GetBreeds(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateBreed([FromBody] BreedCreateRequestDto request)
        {
            try
            {
                var res = await this._breedApplication.CreateBreed(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<ActionResult> SearchBreed([FromBody] BreedSearchRequestDto request)
        {
            try
            {
                var res = await _breedApplication.SearchBreed(request);
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
        public async Task<ActionResult> DeleteBreed([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _breedApplication.DeleteBreed(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


