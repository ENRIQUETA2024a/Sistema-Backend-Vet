using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Products
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;

        public ProductApplication(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request)
        {
            return await _productService.CreateProduct(request);
        }

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            return await _productService.DeleteProduct(request);
        }

        public async Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request)
        {
            return await _productService.GetProducts(request);
        }
    }
}
