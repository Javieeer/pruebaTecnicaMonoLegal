/* Nombre para llamarlo desde otros lugares */
namespace InvoiceReminder.API.Services;

/* Servicio para enviar correos electrónicos */
public class EmailService : IEmailService
{
    /* Enviar un correo electrónico */
    public async Task EnviarCorreoAsync(
        string destinatario,
        string asunto,
        string mensaje)
    {
        /* Simular el envío de un correo electrónico */
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"PARA: {destinatario}");
        Console.WriteLine($"ASUNTO: {asunto}");
        Console.WriteLine($"MENSAJE: {mensaje}");
        Console.WriteLine("--------------------------------");

        await Task.CompletedTask;
    }
}