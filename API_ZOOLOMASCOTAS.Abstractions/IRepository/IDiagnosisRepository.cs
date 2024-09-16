using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Diagnoses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IDiagnosisRepository
    {
        public Task<ResultDto<DiagnosisListResponseDto>> GetDiagnosis(DiagnosisListRequestDto request);
        public Task<ResultDto<int>> CreateDiagnosis(DiagnosisCreateRequestDto request);
        public Task<ResultDto<int>> DeleteDiagnosis(DeleteDto request);
    }
}
