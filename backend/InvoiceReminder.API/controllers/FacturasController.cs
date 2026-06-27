using InvoiceReminder.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

/* Nombre para llamarlo desde otros lugares */
namespace InvoiceReminder.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FacturasController : ControllerBase
{
    /* Servicio para gestionar las facturas */
    private readonly IFacturaService _service;

    /* Constructor */
    public FacturasController(IFacturaService service)
    {
        _service = service;
    }

    /* Obtener todas las facturas */
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var facturas = await _service.GetAllAsync();

        return Ok(facturas);
    }

    /* Procesar recordatorios */
    [HttpPost("procesar")]
    public async Task<IActionResult> Procesar()
    {
        await _service.ProcesarRecordatoriosAsync();

        return Ok(
            "Facturas procesadas correctamente");
    }
}