using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Products;
using API_ZOOLOMASCOTAS.DTOs.Ventas;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Ventas
{
    public class VentaRepository : IVentaRepository
    {
        private string _connectionString = "";
        public VentaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }
        public async Task<ResultDto<int>> AgregarOActualizarDetalleVenta(AgregarOActualizarDetalleVentaDto request)
        {
            throw new NotImplementedException();
        }

        public Task EliminarDetalleVentaAsync(int idDetalle)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<ListarVentasResponseDto>> ListarVentas(VentaListRequestDto request)
        {
            ResultDto<ListarVentasResponseDto> res = new ResultDto<ListarVentasResponseDto>();
            List<ListarVentasResponseDto> list = new List<ListarVentasResponseDto>();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_index", request.index);
                parameters.Add("@p_limit", request.limit);

                using (var cn = new SqlConnection(_connectionString))
                {
                    list = (List<ListarVentasResponseDto>)await cn.QueryAsync<ListarVentasResponseDto>("SP_LIST_VENTAS", parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        public Task RecalcularTotalVentaAsync(int idVenta)
        {
            throw new NotImplementedException();
        }
    }
}