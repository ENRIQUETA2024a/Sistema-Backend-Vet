using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Exams;
using CloudinaryDotNet.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Exams
{
    public class ExamRepository : IExamRepository
    {
        private string _connectionString = "";
        private IConfiguration configuration;
        public ExamRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
            this.configuration = configuration;
        }

        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_mucosa", request.mucosa);
                    parameters.Add("@p_piel", request.piel);
                    parameters.Add("@p_conjuntival", request.conjuntival);
                    parameters.Add("@p_oral", request.oral);
                    parameters.Add("@p_sis_reproductor", request.sis_reproductor);
                    parameters.Add("@p_rectal", request.rectal);
                    parameters.Add("@p_ojos", request.ojos);
                    parameters.Add("@p_nodulos_linfaticos", request.nodulos_linfaticos);
                    parameters.Add("@p_locomocion", request.locomocion);
                    parameters.Add("@p_sis_cardiovascular", request.sis_cardiovascular);
                    parameters.Add("@p_sis_respiratorio", request.sis_respiratorio);
                    parameters.Add("@p_sis_digestivo", request.sis_digestivo);
                    parameters.Add("@p_sis_urinario", request.sis_urinario);
                    parameters.Add("@p_id_consulta", request.consult_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_EXAMS", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_EXAM", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request)
        {
            ResultDto<ExamListResponseDto> res = new ResultDto<ExamListResponseDto>();
            List<ExamListResponseDto> list = new List<ExamListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@p_consult_id", request.consult_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ExamListResponseDto>)await cn.QueryAsync<ExamListResponseDto>("SP_LIST_EXAMS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRecords : 0;
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
