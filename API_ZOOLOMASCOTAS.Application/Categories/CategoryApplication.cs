using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Categories;
using API_ZOOLOMASCOTAS.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Categories
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryService _categoryService;

        public CategoryApplication(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ResultDto<int>> CreateCategories(CategoriesCreateRequestDto request)
        {
            return await _categoryService.CreateCategories(request);
        }

        public async Task<ResultDto<int>> DeleteCategories(DeleteDto request)
        {
            return await _categoryService.DeleteCategories(request);
        }

        public async Task<ResultDto<CategoriesListResponseDto>> GetCategories(CategoriesListRequestDto request)
        {
            return await _categoryService.GetCategories(request);
        }
    }
}
