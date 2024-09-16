using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/treatments")]
    [Authorize]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentsApplication _application;
        private readonly IProductsTreatmentApplication _productsTreatmentApplication;

        public TreatmentsController(ITreatmentsApplication application, IProductsTreatmentApplication productsTreatmentApplication)
        {
            _application = application;
            _productsTreatmentApplication = productsTreatmentApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetTreatments([FromBody] TreatmentsListRequestDto request)
        {
            try
            {
                var res = await this._application.GetTreatments(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] TreatmentsCreateRequestDto request)
        {
            try
            {
                var res = await this._application.CreateTreatment(request);
                //eliminar los productos del tratamiento
                await this._productsTreatmentApplication.DeleteProductsTreatment(res.Item);
                // se obtiene el id del tratamiento
                request.products.ForEach(item =>
                {
                    item.treatment_id = res.Item;
                });

                await this._productsTreatmentApplication.CreateProductsTreatment(request.products);
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
                var res = await _application.DeleteTreatment(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("products/list")]

        public async Task<ActionResult> GetProductsTreatments([FromBody] ProductsTreatmentsListRequestDto request)
        {
            try
            {
                var res = await this._productsTreatmentApplication.GetProductsTreatment(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("detail")]

        public async Task<ActionResult> DetailTreatment([FromBody] ProductsTreatmentsListRequestDto request)
        {
            try
            {
                var res = await this._application.GetDetailTreatment(request.treatment_id);
                var products = await this._productsTreatmentApplication.GetProductsTreatment(request);
                return Ok(new { res, products });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

