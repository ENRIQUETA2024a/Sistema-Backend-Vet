using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface IRolApplication
    {
        public Task<ResultDto<RolesListResponseDto>> GetRoles(RolesListRequestDto request);
        public Task<ResultDto<int>> CreateRoles(RolCreateRequestDto request);
        public Task<ResultDto<int>> DeleteRoles(DeleteDto request);
    }
}
