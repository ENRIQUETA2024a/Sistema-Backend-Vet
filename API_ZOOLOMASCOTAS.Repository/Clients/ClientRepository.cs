using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Clients
{
    public class ClientRepository : IClientRepository
    {
        private string _connectionString = "";
        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }

        public async Task<ResultDto<int>> CreateClient(ClientCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_names", request.names);
                    parameters.Add("@p_lastnames", request.lastnames);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_document_number", request.document_number);
                    parameters.Add("@p_document_type", request.document_type);
                    parameters.Add("@p_phone", request.phone);
                    parameters.Add("@p_address", request.address);
                    parameters.Add("@p_city", request.city);
                    parameters.Add("@p_email", request.email);
                    parameters.Add("@p_registrationDate", request.registrationDate ?? DateTime.Now);
                    parameters.Add("@p_idEmployeeCreates", request.idEmployeeCreates.HasValue ? request.idEmployeeCreates : null);
                    parameters.Add("@p_idEmployeeModifies", request.idEmployeeModifies.HasValue ? request.idEmployeeModifies : null);

                    parameters.Add("@p_public_id", request.public_id);
                    //parameters.Add("@p_signature", request.signature);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_CLIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información guardada o actualizada con exito" : "Información no se puedo guardar la información";
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

        public async Task<ResultDto<int>> DeleteClient(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_CLIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<ClientDetailResponseDto>> GetClientDetail(DeleteDto request)
        {
            ResultDto<ClientDetailResponseDto> res = new ResultDto<ClientDetailResponseDto>();
            ClientDetailResponseDto item = new ClientDetailResponseDto();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<ClientDetailResponseDto>("SP_GET_CLIENT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (ClientDetailResponseDto)query.FirstOrDefault();
                    res.IsSuccess = query.Any() ? true : false;
                    res.Message = query.Any() ? "Información encontrada" : "No se encontró información";
                    res.Item = item;
                }

            }
            catch (Exception ex)
            {
                res.MessageException=ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<ClientListResponseDto>> GetClients(ClientListRequestDto request)
        {
            ResultDto<ClientListResponseDto> res = new ResultDto<ClientListResponseDto>();
            List<ClientListResponseDto> list = new List<ClientListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ClientListResponseDto>) await cn.QueryAsync<ClientListResponseDto>("SP_LIST_CLIENTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRegisters : 0;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<ClientListResponseDto>> SearchClient(ClientSearchRequestDto request)
        {
            ResultDto<ClientListResponseDto> res = new ResultDto<ClientListResponseDto>();
            List<ClientListResponseDto> list = new List<ClientListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_search", request.search);
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ClientListResponseDto>)await cn.QueryAsync<ClientListResponseDto>(
                        "SP_SEARCH_CLIENT",
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
    }
}
