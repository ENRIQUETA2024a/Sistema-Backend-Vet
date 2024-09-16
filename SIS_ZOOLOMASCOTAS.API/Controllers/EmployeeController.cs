using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeApplication _employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }
        [HttpPost]
        [Route("list")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult> GetEmployees([FromBody] EmployeesListRequestDto request)
        {
            try
            {
                var res = await _employeeApplication.GetEmployees(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeCreateRequestDto request)
        {
            try
            {
                var res = await this._employeeApplication.CreateEmployees(request);
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
        public async Task<ActionResult> DeleteEmployee([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _employeeApplication.DeleteEmployees(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

