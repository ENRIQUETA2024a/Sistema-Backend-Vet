using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using API_ZOOLOMASCOTAS.DTOs.User;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Species
{
    public class SpecieRepository : ISpecieRepository
    {
        private string _connectionString = "";
        private IConfiguration configuration;
        public SpecieRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
            this.configuration = configuration;
        }

        public async Task<ResultDto<int>> CreateSpecie(SpecieCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using(var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);
                    parameters.Add("@p_scientificName", request.scientificName);
                    

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_SPECIE", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while(lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información guardada o actualizada con exito" : "Información no se puedo guardar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess=false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<int>> DeleteSpecie(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using( var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    using(var lector = await cn.ExecuteReaderAsync("SP_DELETE_SPECIE", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Item = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = Convert.ToInt32(lector["id"].ToString()) > 0 ? true : false;
                            res.Message = Convert.ToInt32(lector["id"].ToString()) > 0 ? "Información eliminada correctamente" : "Información no se pudo eliminar";
                        }
                    }
                }
            }catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<SpecieListResponseDto>> GetAll(SpecieListRequestDto request)
        {
            ResultDto<SpecieListResponseDto> result = new ResultDto<SpecieListResponseDto>();
            List<SpecieListResponseDto> list = new List<SpecieListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using(var cn = new SqlConnection(_connectionString))
                {
                    list = (List<SpecieListResponseDto>) await cn.QueryAsync<SpecieListResponseDto>("SP_LIST_SPECIES", parameters, commandType:System.Data.CommandType.StoredProcedure);
                }
                result.IsSuccess = list.Count > 0 ? true : false;
                result.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                result.Data = list.ToList();
                result.Total = list.Count >0 ? list[0].totalRegisters : 0;
            }
            catch (Exception ex) 
            {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }

        public async Task<ResultDto<SpecieListResponseDto>> SearchSpecie(SpecieSearchRequestDto request)
        {
            ResultDto<SpecieListResponseDto> res = new ResultDto<SpecieListResponseDto>();
            List<SpecieListResponseDto> list = new List<SpecieListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_name", request.name);
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<SpecieListResponseDto>)await cn.QueryAsync<SpecieListResponseDto>(
                        "SP_SEARCH_SPECIE",
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
