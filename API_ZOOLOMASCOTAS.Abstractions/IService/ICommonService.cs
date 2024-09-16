using API_ZOOLOMASCOTAS.DTOs.Clients;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface ICommonService
    {
        public Task<ClientResultUploadImageDto> SaveImage(IFormFile photo);
        public Task<string> DeleteImage(string publicId);
    }
}
