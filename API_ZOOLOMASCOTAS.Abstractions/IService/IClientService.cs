﻿using API_ZOOLOMASCOTAS.DTOs;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface IClientService
    {
        public Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request);
        public Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request);
        public Task<ResultDto<int>> DeleteClient(DeleteDto request);
        public Task<ResultDto<ClientListResponseDto>> SearchClient(ClientSearchRequestDto request);
        
    }
}
