using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Patients;
using CloudinaryDotNet.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private string _connectionString = "";
        private IConfiguration configuration;
        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
            this.configuration = configuration;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_names", request.names);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_birthday", request.birthday);
                    parameters.Add("@p_age", request.age);
                    parameters.Add("@p_sex", request.sex);
                    parameters.Add("@p_color", request.color);
                    parameters.Add("@p_fur", request.fur);
                    parameters.Add("@p_particularity", request.particularity);
                    parameters.Add("@p_allergy", request.allergy);
                    parameters.Add("@p_breed_id", request.breed_id);
                    parameters.Add("@p_client", request.client_id);
                    parameters.Add("@p_public_id", request.public_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_PATIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_PATIENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<PatientListResponseDto>> GetPatientDetail(DeleteDto request)
        {
            ResultDto<PatientListResponseDto> res = new ResultDto<PatientListResponseDto>();
            PatientListResponseDto item = new PatientListResponseDto();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<PatientListResponseDto>("SP_GET_PATIENT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (PatientListResponseDto)query.FirstOrDefault();
                    res.IsSuccess = query.Any() ? true : false;
                    res.Message = query.Any() ? "Información encontrada" : "No se encontró información";
                    res.Item = item;
                }

            }
            catch (Exception ex)
            {
                res.MessageException = ex.Message;
                res.IsSuccess = false;
            }
            return res;
        }

        public async Task<ResultDto<PatientListResponseDto>> GetPatients(PatientListRequestDto request)
        {
            ResultDto<PatientListResponseDto> res = new ResultDto<PatientListResponseDto>();
            List<PatientListResponseDto> list = new List<PatientListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);
                parameters.Add("@p_client_id", request.client_id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<PatientListResponseDto>)await cn.QueryAsync<PatientListResponseDto>("SP_LIST_PATIENTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                res.IsSuccess = list.Count > 0 ? true : false;
                res.Message = list.Count > 0 ? "Información encontrada" : "No se encontro información";
                res.Data = list.ToList();
                res.Total = list.Count > 0 ? list[0].totalRegisters : 0;
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
