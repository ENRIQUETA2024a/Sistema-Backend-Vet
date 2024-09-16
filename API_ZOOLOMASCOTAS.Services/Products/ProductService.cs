using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Products;
using API_ZOOLOMASCOTAS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICommonService _commonService;

        public ProductService(IProductRepository productRepository, ICommonService commonService)
        {
           _productRepository = productRepository;
           _commonService = commonService;
        }
        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request)
        {
            if (request.photo != null)
            {
                var res = await _commonService.SaveImage(request.photo);
                if (res.isSuccess)
                {
                    request.uri_photo = res.uploadResult?.SecureUrl.ToString();
                    request.public_id = res.uploadResult?.PublicId;
                }
            }
            return await _productRepository.CreateProduct(request);
        }

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            var product = await _productRepository.GetProductDetail(request);
            await _commonService.DeleteImage(product.Item?.public_id);
            return await _productRepository.DeleteProduct(request);
        }

        public async Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request)
        {
            return await _productRepository.GetProducts(request);
        }
    }
}
