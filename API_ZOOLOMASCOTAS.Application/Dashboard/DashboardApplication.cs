using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Dashboard
{
    public class DashboardApplication : IDashboardApplication
    {
        private readonly IDashboardService _service;

        public DashboardApplication(IDashboardService service)
        {
            _service = service;
        }
        public async Task<ResultDto<DashboardInfoResponseDto>> GetDashboardInfo()
        {
           return await this._service.GetDashboardInfo();
        }
    }
}
