using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Auth;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.User;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString = "";
        private IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
            this.configuration = configuration;
        }

        public async Task<ResultDto<int>> Create(UserCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_username", request.username);
                    parameters.Add("@p_password", request.password);
                    parameters.Add("@p_role_id", request.role_id);
                    parameters.Add("@p_employee_id", request.employee_id);
                    parameters.Add("@p_registrationDate", request.registrationDate ?? DateTime.Now);
                    parameters.Add("@p_idEmployeeCreates", request.idEmployeeCreates);
                    parameters.Add("@p_idEmployeeModifies", request.idEmployeeModifies);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_USER", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información guardada o actualizada correctamente" : "Información no se pudo guardar";
                        }

                    }
                }
            }
            catch (Exception ex) 
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<int>> Delete(DeleteDto request)
        {
          ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("p_idEmployeeDeletes", request.idEmployeeDeletes);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_USER", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información eliminada correctamente" : "Información no se pudo eliminar";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<UserListResponseDTO>> GetAll(UserListRequestDto request)
        {
            ResultDto<UserListResponseDTO> res = new ResultDto<UserListResponseDTO>();
            List<UserListResponseDTO> list = new List<UserListResponseDTO>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<UserListResponseDTO>)await cn.QueryAsync<UserListResponseDTO>
                    ("SP_LIST_USERS", parameters, null, commandType: System.Data.CommandType.StoredProcedure);
                }
                res.IsSuccess = list.Count > 0;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontró información";
                res.Data = list;
                res.Total = list.Any() ? list[0].totalRegisters : 0;
            }
            catch (Exception ex) 
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<UserListResponseDTO>> SearchUsersByUsername(UserSearchRequestDto request)
        {
            ResultDto<UserListResponseDTO> res = new ResultDto<UserListResponseDTO>();
            List<UserListResponseDTO> list = new List<UserListResponseDTO>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_username", request.username);
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<UserListResponseDTO>)await cn.QueryAsync<UserListResponseDTO>(
                        "SP_SEARCH_USERS_BY_USERNAME",
                        parameters,
                        null,
                        commandType: System.Data.CommandType.StoredProcedure);
                }

                res.IsSuccess = list.Count > 0;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontró información";
                res.Data = list;  
                res.Total = list.Count > 0 ? list[0].totalRegisters : 0;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }

            return res;
        }

        public async Task<UserDetailResponseDto> GetUserByUsername(string username)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@p_username", username);

            using (var cn = new SqlConnection(_connectionString))
            {
                var query = await cn.QueryAsync<UserDetailResponseDto>("SP_GET_USER_BY_USERNAME", parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (query.Any())
                {
                    return query.First();
                }
                throw new Exception("Usuario o Contraseña incorrectos");

            }
        }

        public async Task<UserDetailResponseDto> ValidateUser(LoginRequestDto request)
        {
            UserDetailResponseDto user = await GetUserByUsername(request.username);
            if (user.password == request.password)
               
            {
                return user;
            }
            throw new Exception("Usuario o contraseña incorrectos");
        }

        public async Task<TokenResponseDto> GenerateToken(UserDetailResponseDto request)
        {
            var key = configuration.GetSection("JWTSettings:Key").Value;
            var KeyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Name, request.username));
            claims.AddClaim(new Claim(ClaimTypes.Role, request.role_id.ToString()));
            claims.AddClaim(new Claim("employee_id", request.employee_id.ToString()));


            var credentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);

            return new TokenResponseDto { Token = token };
        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            UserDetailResponseDto user = await ValidateUser(request);
            var token = await GenerateToken(user);
            return new AuthResponseDto { IsSuccess = true,  User = user, Token = token.Token };
        }

      
    }
}
