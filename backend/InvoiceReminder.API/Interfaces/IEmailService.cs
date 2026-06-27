/* Servicio para enviar correos electrónicos */
public interface IEmailService
{
    /* Enviar un correo electrónico */
    Task EnviarCorreoAsync(
        string destinatario,
        string asunto,
        string mensaje);
}