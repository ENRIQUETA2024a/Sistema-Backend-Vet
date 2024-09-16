
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<ResultDto<EmployeesListResponseDto>> GetEmployees(EmployeesListRequestDto request);
        public Task<ResultDto<int>> CreateEmployees(EmployeeCreateRequestDto request);
        public Task<ResultDto<int>> DeleteEmployees(DeleteDto request);
    }
}
