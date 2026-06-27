using FluentAssertions;
using InvoiceReminder.API.Interfaces;
using InvoiceReminder.API.Models;
using InvoiceReminder.API.Services;
using Moq;

/* Nombre para llamarlos desde otros lugares */
namespace InvoiceReminder.Tests.Services;

/* Pruebas para el servicio de facturas */
public class FacturaServiceTests
{
    /* Mock del repositorio de facturas */
    private readonly Mock<IFacturaRepository> _repository;

    /* Mock del servicio de correo */
    private readonly Mock<IEmailService> _emailService;

    /* Mock del servicio de facturas */
    private readonly FacturaService _service;

    /* Constructor */
    public FacturaServiceTests()
    {
        _repository = new Mock<IFacturaRepository>();

        _emailService = new Mock<IEmailService>();

        _service = new FacturaService(
            _repository.Object,
            _emailService.Object);
    }

    /* Prueba para verificar que se cambie el estado de la factura de primer recordatorio a segundo */
    [Fact]
    public async Task Debe_cambiar_primer_recordatorio_a_segundo()
    {
        // Arrange
        var factura = new Factura
        {
            Id = "1",
            Cliente = "Juan",
            Email = "juan@gmail.com",
            NumeroFactura = "FAC001",
            Estado = "primerrecordatorio"
        };

        _repository
            .Setup(x => x.GetPendientesAsync())
            .ReturnsAsync(new List<Factura> { factura });

        // Act
        await _service.ProcesarRecordatoriosAsync();

        // Assert
        _repository.Verify(
            x => x.ActualizarEstadoAsync(
                "1",
                "segundorecordatorio"),
            Times.Once);
    }

    /* Prueba para verificar que se cambie el estado de la factura de segundo recordatorio a desactivado */
    [Fact]
    public async Task Debe_cambiar_segundo_recordatorio_a_desactivado()
    {
        // Arrange
        var factura = new Factura
        {
            Id = "2",
            Cliente = "Maria",
            Email = "maria@gmail.com",
            NumeroFactura = "FAC002",
            Estado = "segundorecordatorio"
        };

        _repository
            .Setup(x => x.GetPendientesAsync())
            .ReturnsAsync(new List<Factura> { factura });

        // Act
        await _service.ProcesarRecordatoriosAsync();

        // Assert
        _repository.Verify(
            x => x.ActualizarEstadoAsync(
                "2",
                "desactivado"),
            Times.Once);
    }

    /* Prueba para verificar que se envíe un correo al procesar una factura */
    [Fact]
    public async Task Debe_enviar_correo_al_procesar_factura()
    {
        // Arrange
        var factura = new Factura
        {
            Id = "3",
            Cliente = "Carlos",
            Email = "carlos@gmail.com",
            NumeroFactura = "FAC003",
            Estado = "primerrecordatorio"
        };

        _repository
            .Setup(x => x.GetPendientesAsync())
            .ReturnsAsync(new List<Factura> { factura });

        // Act
        await _service.ProcesarRecordatoriosAsync();

        // Assert
        _emailService.Verify(
            x => x.EnviarCorreoAsync(
                factura.Email,
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Once);
    }
}