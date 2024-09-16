using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Application.Diagnoses;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Diagnoses;
using API_ZOOLOMASCOTAS.DTOs.Exams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{

    [ApiController]
    [Route("api/diagnosis")]
    [Authorize]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisApplication  diagnosisApplication;

        public DiagnosisController(IDiagnosisApplication diagnosisApplication)
        {
            this.diagnosisApplication = diagnosisApplication;
        }
        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetDiagnosis([FromBody] DiagnosisListRequestDto request)
        {
            try
            {
                var res = await this.diagnosisApplication.GetDiagnosis(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateDiagnosis([FromBody] DiagnosisCreateRequestDto request)
        {
            try
            {
                var res = await this.diagnosisApplication.CreateDiagnosis(request);
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
        public async Task<ActionResult> DeleteDiagnosis([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this.diagnosisApplication.DeleteDiagnosis(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
