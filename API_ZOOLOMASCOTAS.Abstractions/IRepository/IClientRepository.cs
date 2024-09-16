using API_ZOOLOMASCOTAS.DTOs.Breeds;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IClientRepository
    {
        public Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
        public Task<ResultDto<ClientDetailResponseDto>> GetClientDetail(DeleteDto request);
        public Task<ResultDto<ClientListResponseDto>> SearchClient(ClientSearchRequestDto request);
    }
}
