using InvoiceReminder.API.Configurations;
using InvoiceReminder.API.Interfaces;
using InvoiceReminder.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

/* Nombre para llamarlo desde otros lugares */
namespace InvoiceReminder.API.Repositories;

/* Repositorio para gestionar las facturas */
public class FacturaRepository : IFacturaRepository
{
    /* Colección de facturas en MongoDB */
    private readonly IMongoCollection<Factura> _facturas;

    /* Constructor */
    public FacturaRepository(
        IOptions<MongoDbSettings> mongoSettings)
    {
        var client = new MongoClient(
            mongoSettings.Value.ConnectionString);

        var database = client.GetDatabase(
            mongoSettings.Value.DatabaseName);

        _facturas = database.GetCollection<Factura>(
            mongoSettings.Value.CollectionName);
    }

    /* Obtener todas las facturas */
    public async Task<List<Factura>> GetAllAsync()
    {
        return await _facturas
            .Find(_ => true)
            .ToListAsync();
    }

    /* Obtener facturas pendientes */
    public async Task<List<Factura>> GetPendientesAsync()
    {
        return await _facturas
            .Find(f =>
                f.Estado == "primerrecordatorio" ||
                f.Estado == "segundorecordatorio")
            .ToListAsync();
    }

    /* Actualizar el estado de una factura */
    public async Task ActualizarEstadoAsync(
        string id,
        string nuevoEstado)
    {
        /* Definir la actualización */
        var update =
            Builders<Factura>
                .Update
                .Set(x => x.Estado, nuevoEstado);

        await _facturas.UpdateOneAsync(
            x => x.Id == id,
            update);
    }
}