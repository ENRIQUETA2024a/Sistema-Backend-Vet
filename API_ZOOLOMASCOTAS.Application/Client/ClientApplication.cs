using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Client
{
    public class ClientApplication : IClientApplication
    {
        private readonly IClientService _clientService;

        public ClientApplication(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            return await _clientService.CreateClient(request);
        }

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            return await _clientService.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            return await _clientService.GetClients(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> SearchClient(ClientSearchRequestDto request)
        {
            return await _clientService.SearchClient(request);
        }
    }
}
