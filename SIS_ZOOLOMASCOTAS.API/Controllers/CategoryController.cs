using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Categories;
using API_ZOOLOMASCOTAS.DTOs.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            this.categoryApplication = categoryApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetAll([FromBody] CategoriesListRequestDto request)
        {
            try
            {
                var res = await categoryApplication.GetCategories(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CategoriesCreateRequestDto request)
        {
            try
            {
                var res = await categoryApplication.CreateCategories(request);
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
                var res = await categoryApplication.DeleteCategories(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
