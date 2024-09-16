using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ResultDto<int>> CreateEmployees(EmployeeCreateRequestDto request)
        {
            return await _employeeRepository.CreateEmployees(request);
        }

        public async Task<ResultDto<int>> DeleteEmployees(DeleteDto request)
        {
            return await _employeeRepository.DeleteEmployees(request);
        }

        public async Task<ResultDto<EmployeesListResponseDto>> GetEmployees(EmployeesListRequestDto request)
        {
           return await _employeeRepository.GetEmployees(request);
        }
    }
}
