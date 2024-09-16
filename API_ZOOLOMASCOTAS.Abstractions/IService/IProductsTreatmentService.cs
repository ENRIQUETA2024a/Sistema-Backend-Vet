using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface IProductsTreatmentService
    {
        public Task<ResultDto<ProductsTreatmentsListResponseDto>> GetProductsTreatment(ProductsTreatmentsListRequestDto request);
        public Task<ResultDto<int>> CreateProductsTreatment(List<ProductsTreatmentCreateRequestDto> request);
        public Task<ResultDto<int>> DeleteProductsTreatment( int treatment_id);
    }
}
