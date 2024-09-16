using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Application.Exams;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Consults;
using API_ZOOLOMASCOTAS.DTOs.Exams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/exams")]
    [Authorize]
    public class ExamController : ControllerBase
    {
        private readonly IExamApplication examApplication;

        public ExamController(IExamApplication examApplication)
        {
            this.examApplication = examApplication;
        }
        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetExams([FromBody] ExamListRequestDto request)
        {
            try
            {
                var res = await this.examApplication.GetExams(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateExam([FromBody] ExamCreateRequestDto request)
        {
            try
            {
                var res = await this.examApplication.CreateExam(request);
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
        public async Task<ActionResult> DeleteExam([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this.examApplication.DeleteExam(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
