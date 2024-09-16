using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Patients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    [Authorize]

    public class PatientController : ControllerBase
    {
        private IPatientApplication _patientApplication;

        public PatientController(IPatientApplication patientApplication)
        {
            _patientApplication = patientApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetPatients([FromBody] PatientListRequestDto request)
        {
            try
            {
                var res = await _patientApplication.GetPatients(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreatePatient([FromForm] PatientCreateRequestDto request)
        {
            try
            {
                var res = await this._patientApplication.CreatePatient(request);
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
        public async Task<ActionResult> DeletePatient([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _patientApplication.DeletePatient(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
