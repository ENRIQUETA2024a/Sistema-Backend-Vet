using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Ventas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    [Authorize]
    public class VentasController : ControllerBase
    {
        private readonly IVentaApplication _ventaService;

        public VentasController(IVentaApplication ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost("agregar-actualizar-detalle")]
        public async Task<IActionResult> AgregarOActualizarDetalleVenta([FromBody] AgregarOActualizarDetalleVentaDto dto)
        {
            if (dto == null)
            {
                return BadRequest("El objeto de detalle de venta no puede ser nulo.");
            }

            try
            {
                await _ventaService.AgregarOActualizarDetalleVenta(dto);
                return Ok(new { Message = "Detalle de venta agregado o actualizado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }

        [HttpDelete("eliminar-detalle/{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> EliminarDetalleVenta(int id)
        {
            try
            {
                await _ventaService.EliminarDetalleVentaAsync(id);
                return Ok(new { Message = "Detalle de venta eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }

        [HttpPost("listar")]
        public async Task<IActionResult> ListarVentas([FromBody] VentaListRequestDto request)
        {
            try
            {
                var ventas = await _ventaService.ListarVentas(request);
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error al procesar la solicitud: {ex.Message}" });
            }
        }
    }
}