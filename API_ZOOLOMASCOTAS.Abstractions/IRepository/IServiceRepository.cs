using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IServiceRepository
    {
        public Task<ResultDto<ServiceListResponseDto>> GetServices(ServiceListRequestDto request);
        public Task<ResultDto<int>> CreateService(ServiceCreateRequestDto request);
        public Task<ResultDto<int>> DeleteService(DeleteDto request);
    }
}
