using API_ZOOLOMASCOTAS.DTOs.Breeds;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IBreedRepository
    {
        public Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request);
        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request);
        public Task<ResultDto<int>> DeleteBreed(DeleteDto request);
        public Task<ResultDto<BreedListResponseDto>> SearchBreed(BreedSearchRequestDto request);
    }
}
