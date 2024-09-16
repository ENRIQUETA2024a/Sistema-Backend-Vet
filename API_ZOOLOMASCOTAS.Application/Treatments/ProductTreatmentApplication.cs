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
    public class ProductTreatmentApplication : IProductsTreatmentApplication
    {
        private readonly IProductsTreatmentService _service;

        public ProductTreatmentApplication(IProductsTreatmentService service)
        {
            _service = service;
        }
        public async Task<ResultDto<int>> CreateProductsTreatment(List<ProductsTreatmentCreateRequestDto> request)
        {
            return await this._service.CreateProductsTreatment(request);
        }

        public async Task<ResultDto<int>> DeleteProductsTreatment(int treatment_id)
        {
            return await this._service.DeleteProductsTreatment(treatment_id);
        }

        public async Task<ResultDto<ProductsTreatmentsListResponseDto>> GetProductsTreatment(ProductsTreatmentsListRequestDto request)
        {
            return await this._service.GetProductsTreatment(request);

        }
    }
}
