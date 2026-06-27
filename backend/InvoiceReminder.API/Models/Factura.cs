using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/* Modelo para representar una factura */
namespace InvoiceReminder.API.Models;

public class Factura
{
    /* Identificador único de la factura */
    [BsonId]
    /* Representación del ID como objeto de MongoDB */
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /* Nombre del cliente */
    [BsonElement("cliente")]
    public string Cliente { get; set; } = "";

    /* Dirección de correo electrónico del cliente */
    [BsonElement("email")]
    public string Email { get; set; } = "";

    /* Número de la factura */
    [BsonElement("numeroFactura")]
    public string NumeroFactura { get; set; } = "";

    /* Valor de la factura */
    [BsonElement("valor")]
    public decimal Valor { get; set; }

    /* Estado de la factura */
    [BsonElement("estado")]
    public string Estado { get; set; } = "";
}