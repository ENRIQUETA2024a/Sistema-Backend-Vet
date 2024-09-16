using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Recetas
{
    public class RecetasService : IRecetasService
    {
        private readonly IRecetasRepository recetasRepository;
        public RecetasService(IRecetasRepository recetasRepository)
        {
            this.recetasRepository = recetasRepository;
        }
        public async Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDto request)
        {
           return await this.recetasRepository.CreateReceta(request);
        }

        public async Task<ResultDto<int>> DeleteReceta(DeleteDto request)
        {
            return await this.recetasRepository.DeleteReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDto>> DetailReceta(DeleteDto request)
        {
            return await this.recetasRepository.DetailReceta(request);
        }

        public async Task<ResultDto<RecetasListResponseDto>> GetAllRecetas(RecetasListRequestDto request)
        {
           return await this.recetasRepository.GetAllRecetas(request);
        }
    }
}
