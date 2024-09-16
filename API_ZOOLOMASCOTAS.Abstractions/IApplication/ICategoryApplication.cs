using API_ZOOLOMASCOTAS.DTOs.Categories;
using API_ZOOLOMASCOTAS.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface ICategoryApplication
    {
        public Task<ResultDto<CategoriesListResponseDto>> GetCategories(CategoriesListRequestDto request);
        public Task<ResultDto<int>> CreateCategories(CategoriesCreateRequestDto request);
        public Task<ResultDto<int>> DeleteCategories(DeleteDto request);
    }
}
