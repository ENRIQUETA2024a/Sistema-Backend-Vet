using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Treatments
{
    public class TreatmentsApplication : ITreatmentsApplication
    {
        private readonly ITreatmentsService _service;
        public TreatmentsApplication(ITreatmentsService service)
        {
            _service = service;
        }
        public async Task<ResultDto<int>> CreateTreatment(TreatmentsCreateRequestDto request)
        {
            return await this._service.CreateTreatment(request);
        }

        public async Task<ResultDto<int>> DeleteTreatment(DeleteDto request)
        {
            return await this._service.DeleteTreatment(request);
        }

        public async Task<ResultDto<TreatmentDetailResponseDto>> GetDetailTreatment(int id)
        {
            return await this._service.GetDetailTreatment(id);
        }

        public async Task<ResultDto<TreatmentsListResponseDto>> GetTreatments(TreatmentsListRequestDto request)
        {
            return await this._service.GetTreatments(request);
        }
    }
}
