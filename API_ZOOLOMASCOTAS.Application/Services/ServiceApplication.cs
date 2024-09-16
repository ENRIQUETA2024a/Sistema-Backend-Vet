using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Services
{
    public class ServiceApplication : IServiceApplication
    {
        private readonly IServiceService _serviceService;

        public ServiceApplication(IServiceService serviceService)
        {
            _serviceService = serviceService; 
        }
        public async Task<ResultDto<int>> CreateService(ServiceCreateRequestDto request)
        {
            return await _serviceService.CreateService(request);
        }

        public async Task<ResultDto<int>> DeleteService(DeleteDto request)
        {
           return await _serviceService.DeleteService(request);
        }

        public async Task<ResultDto<ServiceListResponseDto>> GetServices(ServiceListRequestDto request)
        {
            return await _serviceService.GetServices(request);
        }
    }
}
