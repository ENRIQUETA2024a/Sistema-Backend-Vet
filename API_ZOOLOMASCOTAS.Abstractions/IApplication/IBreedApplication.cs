using API_ZOOLOMASCOTAS.DTOs.Breeds;
using API_ZOOLOMASCOTAS.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface IBreedApplication
    {
        public Task<ResultDto<BreedListResponseDto>> GetBreeds(BreedListRequestDto request);
        public Task<ResultDto<int>> CreateBreed(BreedCreateRequestDto request);
        public Task<ResultDto<int>> DeleteBreed(DeleteDto request);
        public Task<ResultDto<BreedListResponseDto>> SearchBreed(BreedSearchRequestDto request);
    }
}
