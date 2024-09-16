using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ResultDto<int>> CreateService(ServiceCreateRequestDto request)
        {
            return await _serviceRepository.CreateService(request);
        }

        public async Task<ResultDto<int>> DeleteService(DeleteDto request)
        {
            return await _serviceRepository.DeleteService(request);
        }

        public async Task<ResultDto<ServiceListResponseDto>> GetServices(ServiceListRequestDto request)
        {
            return await _serviceRepository.GetServices(request);
        }
    }
}
