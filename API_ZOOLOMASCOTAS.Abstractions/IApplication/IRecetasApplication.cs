using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface IRecetasApplication
    {
        public Task<ResultDto<RecetasListResponseDto>> GetAllRecetas(RecetasListRequestDto request);
        public Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDto request);
        public Task<ResultDto<int>> DeleteReceta(DeleteDto request);
        public Task<ResultDto<RecetasListResponseDto>> DetailReceta(DeleteDto request);
    }
}
