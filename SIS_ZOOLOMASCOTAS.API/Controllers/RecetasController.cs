using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Recetas;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using Microsoft.AspNetCore.Authorization;

namespace SIS_ZOOLOMASCOTAS.API.Controllers
{
  
    [ApiController]
    [Route("/api/recetas")]
    [Authorize]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetasApplication _recetasApplication;

        public RecetasController(IRecetasApplication recetasApplication)
        {
            _recetasApplication = recetasApplication;
        }

        [HttpPost]
        [Route("list")]

        public async Task<ActionResult> GetAll([FromBody] RecetasListRequestDto request)
        {
            try
            {
                var res = await _recetasApplication.GetAllRecetas(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] RecetasCreateRequestDto request)
        {
            try
            {
                var res = await this._recetasApplication.CreateReceta(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await _recetasApplication.DeleteReceta(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("pdf")]
        public async Task<ActionResult> GeneratePDF(DeleteDto request)
        {
            try
            {
                var res = await this._recetasApplication.DetailReceta(request);

                var doc = Document.Create(document =>
                {
                    document.Page(page =>
                    {
                        page.Margin(30);
                        page.Header().ShowOnce().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().AlignCenter().Text("Receta ZooloMascotas").Bold().FontSize(20).FontColor("#017bbe");
                            });
                        });
                        page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text(text =>
                                {
                                    text.Span("Paciente: ").SemiBold().FontSize(12).FontColor("#017bbe");
                                    text.Span(res.Item.patient).SemiBold().FontSize(12).FontColor("#017bbe");
                                });
                            });
                            column.Item().PaddingVertical(10);
                            column.Item().Column(col =>
                            {
                                col.Item().Text("Descripcion").FontColor("#017bbe");
                                col.Item().PaddingVertical(2);
                                col.Item().Border(0.5f).BorderColor("#017bbe").Padding(10).Text(res.Item.description).FontSize(10);
                            });
                            column.Item().PaddingVertical(10);
                            column.Item().Column(col =>
                            {
                                col.Item().Text("Indicaciones").FontColor("#017bbe");
                                col.Item().PaddingVertical(2);
                                col.Item().Border(0.5f).BorderColor("#017bbe").Padding(10).Text(res.Item.indicaciones).FontSize(10);
                            });
                        });

                        page.Footer()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Pagina ").FontSize(10);
                            text.CurrentPageNumber().FontSize(10);
                            text.Span(" de ").FontSize(10);
                            text.TotalPages().FontSize(10);
                        });
                    });
                }).GeneratePdf();

                return File(doc, "application/pdf", "receta.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
