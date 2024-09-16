using API_ZOOLOMASCOTAS.DTOs.Clients;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using Microsoft.Extensions.Configuration;

namespace API_ZOOLOMASCOTAS.Services.Common
{
    public class CommonService : ICommonService
    {
        private string _cloudinaryUri;
        public CommonService(
            IConfiguration configuration)
        {
            _cloudinaryUri = configuration.GetSection("Cloudinary").GetSection("URL").Value;
        }

        public async Task<ClientResultUploadImageDto> SaveImage(IFormFile photo)
        {
            ClientResultUploadImageDto result = new ClientResultUploadImageDto();
            try
            {
                Cloudinary cloudinary = new Cloudinary(_cloudinaryUri);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(photo.FileName, photo.OpenReadStream()),
                    UseFilename = true,
                    Overwrite = true,
                    Folder = "sig_veterinary"
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                result.isSuccess = true;
                result.uploadResult = uploadResult;
            }
            catch (Exception ex)
            {
                result.messageException = ex.Message;
                result.isSuccess = false;
            }
            return result;
        }

        public async Task<string> DeleteImage(string publicId)
        {
            try
            {
                Cloudinary cloudinary = new Cloudinary(_cloudinaryUri);
                var deleteParams = new DeletionParams(publicId);
                var result = await cloudinary.DestroyAsync(deleteParams);
                return result.Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
