using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Specie
{
    public class SpecieApplication : ISpecieApplication
    {
        private ISpecieService _specieService;

        public SpecieApplication(ISpecieService specieService)
        {
            _specieService = specieService;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            return await _specieService.CreateSpecie(request);
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            return await _specieService.DeleteSpecie(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            return await _specieService.GetAll(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> SearchSpecie(SpecieSearchRequestDto request)
        {
            return await _specieService.SearchSpecie(request);
        }
    }
}
