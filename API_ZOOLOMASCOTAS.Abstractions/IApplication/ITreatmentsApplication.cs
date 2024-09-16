using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface ITreatmentsApplication
    {
        public Task<ResultDto<TreatmentsListResponseDto>> GetTreatments(TreatmentsListRequestDto request);
        public Task<ResultDto<int>> CreateTreatment(TreatmentsCreateRequestDto request);
        public Task<ResultDto<int>> DeleteTreatment(DeleteDto request);
        public Task<ResultDto<TreatmentDetailResponseDto>> GetDetailTreatment(int id);
    }
}
