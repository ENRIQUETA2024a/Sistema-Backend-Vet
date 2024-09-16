using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Consults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Consults
{
    public class ConsultService : IConsultService
    {
        private readonly IConsultRepository consulRepository;
        public ConsultService(IConsultRepository consulRepository)
        {
            this.consulRepository = consulRepository;
        }

        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request)
        {
           return await this.consulRepository.CreateConsult(request);
        }

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            return await this.consulRepository.DeleteConsult(request);  
        }

        public async Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request)
        {
            return await this.consulRepository.GetConsults(request);
        }
    }
}
