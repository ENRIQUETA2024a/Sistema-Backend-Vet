using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardApplication dashboardApplication;

        public DashboardController(IDashboardApplication dashboardApplication)
        {
            this.dashboardApplication = dashboardApplication;
        }

        [HttpGet]
        [Route("info")]
        public async Task<ActionResult>GetDashboardInfo()
        {
            try
            {
                var res = await this.dashboardApplication.GetDashboardInfo();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
