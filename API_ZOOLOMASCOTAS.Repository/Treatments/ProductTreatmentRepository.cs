using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Products;
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
    public class ProductTreatmentRepository : IProductsTreatmentRepository
    {
        private string _connectionString;

        public ProductTreatmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }

        public async Task<ResultDto<int>> CreateProductsTreatment(List<ProductsTreatmentCreateRequestDto> _request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                foreach (ProductsTreatmentCreateRequestDto request in _request)
                {
                    using (var cn = new SqlConnection(_connectionString))
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@p_id", request.id);
                        parameters.Add("@p_treatment_id", request.treatment_id);
                        parameters.Add("@p_product_id", request.product_id);

                        using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_PRODUCTS_TREATMENTS", parameters, commandType: System.Data.CommandType.StoredProcedure))
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
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }

        public async Task<ResultDto<int>> DeleteProductsTreatment(int treatment_id)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_treatment_id", treatment_id);
                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_PRODUCT_TREATMENT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<ProductsTreatmentsListResponseDto>> GetProductsTreatment(ProductsTreatmentsListRequestDto request)
        {
            ResultDto<ProductsTreatmentsListResponseDto> result = new ResultDto<ProductsTreatmentsListResponseDto>();
            List<ProductsTreatmentsListResponseDto> list = new List<ProductsTreatmentsListResponseDto>();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_index", request.index);
                    parameters.Add("@p_limit", request.limit);
                    parameters.Add("@p_treatment_id", request.treatment_id);

                    list = (List<ProductsTreatmentsListResponseDto>)await cn.QueryAsync<ProductsTreatmentsListResponseDto>("SP_LIST_PRODUCTS_TREATMENTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
