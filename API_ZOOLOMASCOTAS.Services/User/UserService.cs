using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Auth;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.User
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ResultDto<int>> Create(UserCreateRequestDto request)
        {
           return await userRepository.Create(request);
        }

        public async Task<ResultDto<int>> Delete(DeleteDto request)
        {
            return await userRepository.Delete(request);
        }

        public  async Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request)
        {
            return await userRepository.GetAll(request);
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            return await userRepository.Login(request);
        }

        public async Task<ResultDto<UserListResponseDTO>> SearchUsersByUsername(UserSearchRequestDto request)
        {
            return await userRepository.SearchUsersByUsername(request);
        }
    }
}
