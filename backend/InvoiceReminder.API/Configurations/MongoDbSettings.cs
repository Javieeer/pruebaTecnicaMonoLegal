/* Nombre para llamarlo desde otros lugares */
namespace InvoiceReminder.API.Configurations;

/* Configuración para la conexión a MongoDB */
public class MongoDbSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;
}