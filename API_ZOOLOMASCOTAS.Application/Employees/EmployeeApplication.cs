using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Employees
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApplication(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<ResultDto<int>> CreateEmployees(EmployeeCreateRequestDto request)
        {
           return await _employeeService.CreateEmployees(request);
        }

        public async Task<ResultDto<int>> DeleteEmployees(DeleteDto request)
        {
            return await _employeeService.DeleteEmployees(request);
        }

        public async Task<ResultDto<EmployeesListResponseDto>> GetEmployees(EmployeesListRequestDto request)
        {
            return await _employeeService.GetEmployees(request);
        }
    }
}
