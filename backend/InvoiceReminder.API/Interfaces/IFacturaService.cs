using InvoiceReminder.API.Models;

/* Nombre para llamarlo desde otros lugares */
namespace InvoiceReminder.API.Interfaces;

/* Servicio para gestionar las facturas */
public interface IFacturaService
{
    /* Obtener todas las facturas */
    Task<List<Factura>> GetAllAsync();

    /* Procesar recordatorios */
    Task ProcesarRecordatoriosAsync();
}