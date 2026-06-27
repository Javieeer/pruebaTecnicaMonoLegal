using InvoiceReminder.API.Interfaces;
using InvoiceReminder.API.Models;

/* Nombre para llamarlos desde otros lugares */
namespace InvoiceReminder.API.Services;

/* Servicio para gestionar las facturas */
public class FacturaService : IFacturaService
{
    /* Repositorio para gestionar las facturas */
    private readonly IFacturaRepository _repository;
    /* Servicio para enviar correos electrónicos */
    private readonly IEmailService _emailService;

    /* Constructor */
    public FacturaService(
        IFacturaRepository repository,
        IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    /* Obtener todas las facturas */
    public async Task<List<Factura>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /* Procesar recordatorios */
    public async Task ProcesarRecordatoriosAsync()
    {
        /* Obtener las facturas pendientes */
        var facturas =
            await _repository.GetPendientesAsync();

        foreach(var factura in facturas)
        {
            /* Procesar cada factura pendiente */
            if(factura.Estado == "primerrecordatorio")
            {
                /* Enviar correo de segundo recordatorio */
                await _emailService.EnviarCorreoAsync(
                    factura.Email,
                    "Segundo recordatorio",
                    $"La factura {factura.NumeroFactura} ha pasado a segundo recordatorio");

                await _repository.ActualizarEstadoAsync(
                    factura.Id!,
                    "segundorecordatorio");
            }
            else if(factura.Estado == "segundorecordatorio")
            {
                /* Enviar correo de desactivación */
                await _emailService.EnviarCorreoAsync(
                    factura.Email,
                    "Desactivación",
                    $"La factura {factura.NumeroFactura} será desactivada");

                await _repository.ActualizarEstadoAsync(
                    factura.Id!,
                    "desactivado");
            }
        }
    }
}