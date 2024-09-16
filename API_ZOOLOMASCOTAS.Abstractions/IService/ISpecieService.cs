
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using API_ZOOLOMASCOTAS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface ISpecieService
    {
        public Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request);
        public Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request);
        public Task<ResultDto<int>> DeleteSpecie(DeleteDto request);
        public Task<ResultDto<SpecieListResponseDto>> SearchSpecie(SpecieSearchRequestDto request);
    }
}
