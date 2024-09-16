using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Specie
{
    public class SpecieService : ISpecieService
    {
        private ISpecieRepository _specieRepository;
        public SpecieService(ISpecieRepository specieRepository)
        {
            _specieRepository = specieRepository;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            return await _specieRepository.CreateSpecie(request);
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            return await _specieRepository.DeleteSpecie(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            return await _specieRepository.GetAll(request);
        }

        public async Task<ResultDto<SpecieListResponseDto>> SearchSpecie(SpecieSearchRequestDto request)
        {
            return await _specieRepository.SearchSpecie(request);
        }
    }
}
