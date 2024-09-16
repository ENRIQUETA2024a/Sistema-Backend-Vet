using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Auth;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.User
{
    public class UserApplication : IUserApplication
    {
        private IUserService _userService;

        public UserApplication(IUserService userService)
        { 
            _userService = userService;
        }

        public async Task<ResultDto<int>> Create(UserCreateRequestDto request)
        {
            return await _userService.Create(request);
        }

        public async Task<ResultDto<int>> Delete(DeleteDto request)
        {
            return await _userService.Delete(request);
        }

        public async Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request)
        {
            return await _userService.GetAll(request);
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
           return await _userService.Login(request);
        }

        public async Task<ResultDto<UserListResponseDTO>> SearchUsersByUsername(UserSearchRequestDto request)
        {
            return await _userService.SearchUsersByUsername(request);
        }
    }
}
