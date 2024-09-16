using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Consults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Consults
{
    public class ConsultApplication : IConsultApplication
    {
        private readonly IConsultService consultservice;

        public ConsultApplication(IConsultService consultservice)
        {
            this.consultservice = consultservice;
        }

        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request)
        {
            return await this.consultservice.CreateConsult(request);
        }

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            return await this.consultservice.DeleteConsult(request);
        }

        public async Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request)
        {
            return await this.consultservice.GetConsults(request);
        }
    }
}
