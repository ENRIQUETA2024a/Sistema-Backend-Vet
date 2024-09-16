using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Clients
{
    public class ClientResultUploadImageDto
    {
        public ImageUploadResult? uploadResult;
        public string? messageException;
        public Boolean isSuccess;
    }
}
