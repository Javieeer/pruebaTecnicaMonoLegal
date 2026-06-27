using InvoiceReminder.API.Configurations;
using InvoiceReminder.API.Interfaces;
using InvoiceReminder.API.Repositories;
using InvoiceReminder.API.Services;

/* Configurar el contenedor de servicios */
var builder = WebApplication.CreateBuilder(args);

/* Agregar servicios al contenedor */
builder.Services.AddControllers();

/* Agregar soporte para puntos de conexión API */
builder.Services.AddEndpointsApiExplorer();

/* Agregar soporte para Swagger */
builder.Services.AddSwaggerGen();

/* Configurar la conexión a MongoDB */
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDb"));

/* Agregar servicio para el manejo de facturas */
builder.Services.AddScoped<IFacturaService, FacturaService>();

/* Agregar servicios de dependencia para el servicio de correo */
builder.Services.AddScoped<IEmailService, EmailService>();

/* Agregar servicio para el repositorio de facturas */
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

/* Configurar CORS */
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy",
        policy =>
        {
            policy
            /* Permite solicitudes desde cualquier origen */
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

/* Construir la aplicación */
var app = builder.Build();

/* Usar CORS */
app.UseCors("AngularPolicy");

/* Configurar el middleware para el entorno de desarrollo */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* Configurar el middleware para redirección HTTPS */
app.UseHttpsRedirection();

/* Configurar el middleware para el manejo de rutas */
app.MapControllers();

/* Ejecutar la aplicación */
app.Run();