using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Species;
using API_ZOOLOMASCOTAS.DTOs.Treatments;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Treatments
{
    public class TreatmentsRepository : ITreatmentsRepository
    {
        private string _connectionString = "";
      
        public TreatmentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }
        public async Task<ResultDto<int>> CreateTreatment(TreatmentsCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);
                parameters.Add("@p_detail", request.detail);
                parameters.Add("@p_diagnosis_id", request.diagnosis_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_TREATMENTS", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteTreatment(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_TREATMENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<TreatmentDetailResponseDto>> GetDetailTreatment(int id)
        {
            ResultDto<TreatmentDetailResponseDto> result = new ResultDto<TreatmentDetailResponseDto>();
            TreatmentDetailResponseDto item = new TreatmentDetailResponseDto();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", id);
                using (var cn = new SqlConnection(_connectionString))
                {
                   var query = await cn.QueryAsync<TreatmentDetailResponseDto> ("SP_DETAIL_TREATMENT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (TreatmentDetailResponseDto) query.FirstOrDefault();
                    result.IsSuccess = query.Any();
                    result.Message = query.Any() ? "Información encontrada" : "No se encontro información";
                    result.Item = item;
                    
                }
               
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }

        public async Task<ResultDto<TreatmentsListResponseDto>> GetTreatments(TreatmentsListRequestDto request)
        {
            ResultDto<TreatmentsListResponseDto> result = new ResultDto<TreatmentsListResponseDto>();
            List<TreatmentsListResponseDto> list = new List<TreatmentsListResponseDto>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_diagnosis_id", request.diagnosis_id);

                    list = (List<TreatmentsListResponseDto>)await cn.QueryAsync<TreatmentsListResponseDto>("SP_LIST_TREATMENTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
