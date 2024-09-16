using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Products;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString = "";
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }
        public async Task<ResultDto<int>> CreateProduct(ProductCreateRequestDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    parameters.Add("@p_name", request.name);
                    parameters.Add("@p_category_id", request.category_id);
                    parameters.Add("@p_laboratory", request.laboratory);
                    parameters.Add("@p_expirationDate", request.expirationDate);
                    parameters.Add("@p_cost", request.cost);
                    parameters.Add("@p_price", request.price);
                    parameters.Add("@p_stock", request.stock);
                    parameters.Add("@p_photo", request.uri_photo);
                    parameters.Add("@p_registrationDate", request.registrationDate ?? DateTime.Now);
                    parameters.Add("@p_idEmployeeCreates", request.idEmployeeCreates.HasValue ? request.idEmployeeCreates : null);
                    parameters.Add("@p_idEmployeeModifies", request.idEmployeeModifies.HasValue ? request.idEmployeeModifies : null);
                    parameters.Add("@p_public_id", request.public_id);

                    using (var lector = await cn.ExecuteReaderAsync("SP_CREATE_PRODUCTS", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<int>> DeleteProduct(DeleteDto request)
        {
            ResultDto<int> res = new ResultDto<int>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@p_id", request.id);
                    //parameters.Add("p_idEmployeeDeletes", request.idEmployeeDeletes);

                    using (var lector = await cn.ExecuteReaderAsync("SP_DELETE_PRODUCT", parameters, commandType: System.Data.CommandType.StoredProcedure))
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

        public async Task<ResultDto<ProductListResponseDto>> GetProductDetail(DeleteDto request)
        {
            ResultDto<ProductListResponseDto> res = new ResultDto<ProductListResponseDto>();
            ProductListResponseDto item = new ProductListResponseDto();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_id", request.id);

                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<ProductListResponseDto>("SP_DETAIL_PRODUCT", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    item = (ProductListResponseDto)query.FirstOrDefault();
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

        public async Task<ResultDto<ProductListResponseDto>> GetProducts(ProductListRequestDto request)
        {
            ResultDto<ProductListResponseDto> res = new ResultDto<ProductListResponseDto>();
            List<ProductListResponseDto> list = new List<ProductListResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ProductListResponseDto>)await cn.QueryAsync<ProductListResponseDto>("SP_LIST_PRODUCTS", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
