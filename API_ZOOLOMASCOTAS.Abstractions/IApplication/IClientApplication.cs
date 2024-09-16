using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface IClientApplication
    {
        public Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
        public Task<ResultDto<ClientListResponseDto>> SearchClient(ClientSearchRequestDto request);
    }
}
