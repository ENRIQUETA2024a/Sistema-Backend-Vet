using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Roles
{
    public class RolService : IRolService
    {
        private IRolRepository rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }
        public async Task<ResultDto<int>> CreateRoles(RolCreateRequestDto request)
        {
            return await rolRepository.CreateRoles(request);
        }

        public async Task<ResultDto<int>> DeleteRoles(DeleteDto request)
        {
            return await rolRepository.DeleteRoles(request);   
        }

        public async Task<ResultDto<RolesListResponseDto>> GetRoles(RolesListRequestDto request)
        {
            return await rolRepository.GetRoles(request);
        }
    }
}
