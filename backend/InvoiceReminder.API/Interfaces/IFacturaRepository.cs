using InvoiceReminder.API.Models;

/* Nombre para llamar desde otros lugares */
namespace InvoiceReminder.API.Interfaces;

/* Repositorio para gestionar las facturas */
public interface IFacturaRepository
{
    /* Obtener todas las facturas */
    Task<List<Factura>> GetAllAsync();

    /* Obtener facturas pendientes */
    Task<List<Factura>> GetPendientesAsync();

    /* Actualizar el estado de una factura */
    Task ActualizarEstadoAsync(
        string id,
        string nuevoEstado);
}