using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Breeds;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Breed
{
    public class BreedApplication : IBreedApplication
    {
        private IBreedService _breedService;

        public BreedApplication(IBreedService breedService)
        {
            _breedService = breedService;
        }

        public async Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request)
        {
            return await _breedService.CreateBreed(request);
        }

        public async Task<ResultDto<int>> DeleteBreed(DeleteDto request)
        {
            return await _breedService.DeleteBreed(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request)
        {
            return await _breedService.GetBreeds(request);
        }

        public async Task<ResultDto<BreedListResponseDto>> SearchBreed(BreedSearchRequestDto request)
        {
            return await _breedService.SearchBreed(request);
        }
    }
}
