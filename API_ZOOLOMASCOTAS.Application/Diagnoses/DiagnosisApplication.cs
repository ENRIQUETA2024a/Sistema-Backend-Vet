using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Diagnoses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Diagnoses
{
    public class DiagnosisApplication : IDiagnosisApplication
    {
        private readonly IDiagnosisService diagnosisService;

        public DiagnosisApplication(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
        }
        public async Task<ResultDto<int>> CreateDiagnosis(DiagnosisCreateRequestDto request)
        {
            return await this.diagnosisService.CreateDiagnosis(request);
        }

        public async Task<ResultDto<int>> DeleteDiagnosis(DeleteDto request)
        {
           return await this.diagnosisService.DeleteDiagnosis(request);
        }

        public async Task<ResultDto<DiagnosisListResponseDto>> GetDiagnosis(DiagnosisListRequestDto request)
        {
            return await this.diagnosisService.GetDiagnosis(request);
        }
    }
}
