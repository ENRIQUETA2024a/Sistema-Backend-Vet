using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Recetas;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Recetas
{
    public class RecetasRepository : IRecetasRepository
    {
        private string _connectionString = "";

        public RecetasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }
        public async Task<ResultDto<int>> CreateReceta(RecetasCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                parameters.Add("@p_description", request.description);
                parameters.Add("@p_indicaciones", request.indicaciones);
                parameters.Add("@p_patient_id", request.patient_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_RECETA", parameters, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        while (lector.Read())
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
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<int>> DeleteReceta(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_RECETA", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<RecetasListResponseDto>> DetailReceta(DeleteDto request)
        {
            ResultDto<RecetasListResponseDto> res = new ResultDto<RecetasListResponseDto>();
            RecetasListResponseDto item = new RecetasListResponseDto();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<RecetasListResponseDto>("SP_DETAIL_RECETA", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (RecetasListResponseDto)query.FirstOrDefault();
                    res.IsSuccess = query.Any();
                    res.Message = query.Any() ? "Información encontrada" : "No se encontro información";
                    res.Item = item;
                   
                }
                
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<RecetasListResponseDto>> GetAllRecetas(RecetasListRequestDto request)
        {
            ResultDto<RecetasListResponseDto> result = new ResultDto<RecetasListResponseDto>();
            List<RecetasListResponseDto> list = new List<RecetasListResponseDto>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_patient_id", request.patient_id);

                    list = (List<RecetasListResponseDto>)await cn.QueryAsync<RecetasListResponseDto>("SP_LIST_RECETAS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                result.IsSuccess = list.Count > 0 ? true : false;
                result.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                result.Data = list.ToList();
                result.Total = list.Count > 0 ? list[0].totalRecords : 0;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }
    }
}
