using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Breeds;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Breed
{
    public class BreedService : IBreedService
    {
        private IBreedRepository _breedRepository;
        public BreedService(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }

        public async Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request)
        {
            return await _breedRepository.CreateBreed(request);
        }

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            return await _breedRepository.DeleteBreed(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request)
        {
            return await _breedRepository.GetBreeds(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> SearchBreed(BreedSearchRequestDto request)
        {
            return await _breedRepository.SearchBreed(request);
        }
    }
}