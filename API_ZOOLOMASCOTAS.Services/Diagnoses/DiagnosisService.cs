using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Diagnoses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Diagnoses
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDiagnosisRepository diagnosisRepository;
        public DiagnosisService(IDiagnosisRepository diagnosisRepository)
        {
            this.diagnosisRepository = diagnosisRepository;
        }

        public async Task<ResultDto<int>> CreateDiagnosis(DiagnosisCreateRequestDto request)
        {
            return await this.diagnosisRepository.CreateDiagnosis(request);
        }

        public async Task<ResultDto<int>> DeleteDiagnosis(DeleteDto request)
        {
            return await this.diagnosisRepository.DeleteDiagnosis(request);
        }

        public async Task<ResultDto<DiagnosisListResponseDto>> GetDiagnosis(DiagnosisListRequestDto request)
        {
            return await this.diagnosisRepository.GetDiagnosis(request);
        }
    }
}
