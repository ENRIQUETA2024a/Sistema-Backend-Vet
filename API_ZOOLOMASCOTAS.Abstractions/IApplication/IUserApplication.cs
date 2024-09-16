using API_ZOOLOMASCOTAS.DTOs.Auth;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface IUserApplication
    {
        public Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request);
        public Task<ResultDto<int>> Create(UserCreateRequestDto request);
        public Task<ResultDto<int>> Delete(DeleteDto request);
        public Task<AuthResponseDto> Login(LoginRequestDto request);
        public Task<ResultDto<UserListResponseDTO>> SearchUsersByUsername(UserSearchRequestDto request);
    }
}
