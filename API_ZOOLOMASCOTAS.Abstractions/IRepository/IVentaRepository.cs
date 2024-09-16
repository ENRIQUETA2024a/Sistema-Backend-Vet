using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Ventas;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IVentaRepository
    {
        public Task<ResultDto<ListarVentasResponseDto>> ListarVentas(VentaListRequestDto request);
        public Task<ResultDto<int>> AgregarOActualizarDetalleVenta(AgregarOActualizarDetalleVentaDto request);
        public Task EliminarDetalleVentaAsync(int idDetalle);
        public Task RecalcularTotalVentaAsync(int idVenta);
    }
}
