using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Treatments
{
    public class TreatmentService : ITreatmentsService
    {
        private readonly ITreatmentsRepository _repository;

        public TreatmentService(ITreatmentsRepository repository)
        { 
            _repository = repository; 
        }
        public async Task<ResultDto<int>> CreateTreatment(TreatmentsCreateRequestDto request)
        {
            return await this._repository.CreateTreatment(request);
        }

        public async Task<ResultDto<int>> DeleteTreatment(DeleteDto request)
        {
           return await this._repository.DeleteTreatment(request);
        }

        public async Task<ResultDto<TreatmentDetailResponseDto>> GetDetailTreatment(int id)
        {
            return await _repository.GetDetailTreatment(id);
        }

        public async Task<ResultDto<TreatmentsListResponseDto>> GetTreatments(TreatmentsListRequestDto request)
        {
           return await this._repository.GetTreatments(request);
        }
    }
}
