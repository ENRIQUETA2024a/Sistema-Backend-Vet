using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface IDashboardService
    {
        public Task<ResultDto<DashboardInfoResponseDto>> GetDashboardInfo();
    }
}
