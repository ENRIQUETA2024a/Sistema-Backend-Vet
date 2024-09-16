using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Consults;
using API_ZOOLOMASCOTAS.DTOs.Patients;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Consults
{
    public class ConsultRepository : IConsultRepository
    {
        private string _connectionString = "";
        private IConfiguration configuration;
        public ConsultRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
            this.configuration = configuration;
        }
        public async Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_reason", request.reason);
                    parameters.Add("@p_antecedents", request.antecedents);
                    parameters.Add("@p_diseases", request.diseases);
                    parameters.Add("@p_next_consult", request.next_consult);
                    parameters.Add("@p_patient_id", request.patient_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_CONSULT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteConsult(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_CONSULT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request)
        {
            ResultDto<ConsultListResponseDto> res = new ResultDto<ConsultListResponseDto>();
            List<ConsultListResponseDto> list = new List<ConsultListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@p_patient_id", request.patient_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ConsultListResponseDto>)await cn.QueryAsync<ConsultListResponseDto>("SP_LIST_CONSULTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRecords : 0;
            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }
    }
}
