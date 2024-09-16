using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface IProductService
    {
        public Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request);
        public Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request);
        public Task<ResultDto<int>> DeleteProduct(DeleteDto request);
    }
}
