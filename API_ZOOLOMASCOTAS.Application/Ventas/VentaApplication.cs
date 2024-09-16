using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Ventas;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Ventas
{
    public class VentaApplication : IVentaApplication
    {
        private readonly IVentaService _ventaService;

        public VentaApplication(IVentaService eventaService)
        {
            _ventaService = eventaService;
        }
        public async Task<ResultDto<int>> AgregarOActualizarDetalleVenta(AgregarOActualizarDetalleVentaDto request)
        {
            return await _ventaService.AgregarOActualizarDetalleVenta(request);
        }

        public async Task EliminarDetalleVentaAsync(int idDetalle)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<ListarVentasResponseDto>> ListarVentas(VentaListRequestDto request)
        {
            return await _ventaService.ListarVentas(request);
        }

        public async Task RecalcularTotalVentaAsync(int idVenta)
        {
            throw new NotImplementedException();
        }
    }
}