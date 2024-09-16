using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Recetas
{
    public class RecetasApplication : IRecetasApplication
    {
        private readonly IRecetasService _recetasService;

        public RecetasApplication(IRecetasService recetasService)
        {
            _recetasService = recetasService;
        }
        public async Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDto request)
        {
            return await this._recetasService.CreateReceta(request);
        }

        public async Task<ResultDto<int>> DeleteReceta(DeleteDto request)
        {
            return await this._recetasService.DeleteReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDto>> DetailReceta(DeleteDto request)
        {
            return await this._recetasService.DetailReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDto>> GetAllRecetas(RecetasListRequestDto request)
        {
            return await this._recetasService.GetAllRecetas(request);
        }
    }
}
