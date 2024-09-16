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
    public class ProductTreatmentService : IProductsTreatmentService
    {
        private readonly IProductsTreatmentRepository _repository;

        public ProductTreatmentService(IProductsTreatmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultDto<int>> CreateProductsTreatment(List<ProductsTreatmentCreateRequestDto> request)
        {
            return await this._repository.CreateProductsTreatment(request);
        }

        public async Task<ResultDto<int>> DeleteProductsTreatment(int treatment_id)
        {
            return await this._repository.DeleteProductsTreatment(treatment_id);
        }

        public async Task<ResultDto<ProductsTreatmentsListResponseDto>> GetProductsTreatment(ProductsTreatmentsListRequestDto request)
        {
            return await this._repository.GetProductsTreatment(request);
        }
    }
}
