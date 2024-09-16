using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly ICommonService commonService;
        //private readonly Cloudinary _cloudinary;
        public ClientService(IClientRepository clientRepository, ICommonService commonService)
        {
            this.clientRepository = clientRepository;
            this.commonService = commonService;
        }
        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            if (request.photo != null)
            {
                var res = await commonService.SaveImage(request.photo);
                if (res.isSuccess)
                {
                    request.uri_photo = res.uploadResult?.SecureUrl.ToString();
                    request.public_id = res.uploadResult?.PublicId;
                }
            }
            return await clientRepository.CreateClient(request);
        }

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            var client = await clientRepository.GetClientDetail(request);
            await commonService.DeleteImage(client.Item?.public_id);    
            return await clientRepository.DeleteClient(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            return await clientRepository.GetClients(request);
        }

        public async Task<ResultDto<ClientListResponseDto>> SearchClient(ClientSearchRequestDto request)
        {
           return await clientRepository.SearchClient(request); 
        }
    }
}


