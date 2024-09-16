using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Ventas
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<ResultDto<int>> AgregarOActualizarDetalleVenta(AgregarOActualizarDetalleVentaDto request)
        {
            return await _ventaRepository.AgregarOActualizarDetalleVenta(request);
        }

        public async Task EliminarDetalleVentaAsync(int idDetalle)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultDto<ListarVentasResponseDto>> ListarVentas(VentaListRequestDto request)
        {
            return await _ventaRepository.ListarVentas(request);
        }

        public async Task RecalcularTotalVentaAsync(int idVenta)
        {
            throw new NotImplementedException();
        }
    }
}
