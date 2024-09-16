using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Roles
{
    public class RolApplication : IRolApplication
    {
        private IRolService _rolService;

        public RolApplication(IRolService rolService)
        {
            _rolService = rolService;
        }
        public async Task<ResultDto<int>> CreateRoles(RolCreateRequestDto request)
        {
            return await _rolService.CreateRoles(request);
        }

        public async Task<ResultDto<int>> DeleteRoles(DeleteDto request)
        {
            return await _rolService.DeleteRoles(request);
        }

        public async Task<ResultDto<RolesListResponseDto>> GetRoles(RolesListRequestDto request)
        {
            return await _rolService.GetRoles(request);
        }
    }
}
