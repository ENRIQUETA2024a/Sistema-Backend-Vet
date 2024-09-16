using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Categories;
using API_ZOOLOMASCOTAS.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResultDto<int>> CreateCategories(CategoriesCreateRequestDto request)
        {
            return await this._categoryRepository.CreateCategories(request);
        }

        public async Task<ResultDto<int>> DeleteCategories(DeleteDto request)
        {
            return await this._categoryRepository.DeleteCategories(request);
        }

        public async Task<ResultDto<CategoriesListResponseDto>> GetCategories(CategoriesListRequestDto request)
        {
            return await this._categoryRepository.GetCategories(request);
        }
    }
}
