# Documento Técnico - Prueba Técnica Monolegal

## Información General

**Candidato:** Javier Alejandro Zapata Ramos  
**Repositorio GitHub:** https://github.com/Javieeer/pruebaTecnicaMonoLegal

---

# 1. Arquitectura de la Solución

La solución fue desarrollada siguiendo una arquitectura en capas, separando claramente las responsabilidades entre presentación, lógica de negocio y acceso a datos.

La aplicación se divide en dos componentes principales:

- **Backend:** API REST desarrollada en ASP.NET Core 8.
- **Frontend:** Aplicación web desarrollada en Angular.

La persistencia se realiza mediante **MongoDB Atlas**, aprovechando una base de datos NoSQL administrada en la nube.

## Arquitectura General

```
Frontend Angular
        │
        ▼
Backend ASP.NET Core API
        │
        ▼
Servicios de Negocio
        │
        ▼
Repositorios
        │
        ▼
MongoDB Atlas
```

---

# 2. Backend

## Tecnologías utilizadas

- ASP.NET Core 8
- MongoDB Driver
- Swagger/OpenAPI
- xUnit
- FluentAssertions

## Estructura del proyecto

```
InvoiceReminder.API
│
├── Controllers
├── Models
├── DTOs
├── Interfaces
├── Services
├── Repositories
├── Configurations
└── Tests
```

## Decisiones tomadas

### Patrón Repository

Se implementó el patrón Repository para desacoplar el acceso a datos de la lógica de negocio.

Ventajas:

- Mayor mantenibilidad.
- Facilita pruebas unitarias.
- Permite reemplazar la capa de persistencia sin afectar la lógica.

### Inyección de Dependencias

Se utilizó el contenedor de dependencias nativo de ASP.NET Core para registrar:

- Servicios de negocio.
- Repositorios.
- Configuración de MongoDB.

Beneficios:

- Bajo acoplamiento.
- Mayor facilidad de testing.
- Mejor escalabilidad.

### Configuración segura

Las credenciales de MongoDB no se almacenan en el repositorio.

Para desarrollo local se utilizaron:

- User Secrets de .NET.
- Variables de entorno.

Esto evita exponer información sensible en Git.

---

# 3. Base de Datos

## Motor

MongoDB Atlas (Cloud NoSQL Database)

## Base de datos

```
InvoiceReminderDB
```

## Colección

```
Facturas
```

## Estructura del documento

```json
{
    "_id": "ObjectId",
    "cliente": "Juan Pérez",
    "email": "juan@gmail.com",
    "numeroFactura": "FAC001",
    "valor": 350000,
    "estado": "primerrecordatorio"
}
```

## Razones para utilizar MongoDB

- Facilidad de configuración.
- Desarrollo rápido.
- Modelo flexible de documentos.
- Escalabilidad horizontal.
- Integración sencilla con ASP.NET Core.

---

# 4. Frontend

## Tecnologías utilizadas

- Angular
- TypeScript
- RxJS
- HttpClient

## Estructura

```
src/app
│
├── models
├── services
└── pages
    └── dashboard
```

## Funcionalidades implementadas

- Consulta de facturas desde el backend.
- Visualización en tabla.
- Consumo de API REST mediante HttpClient.
- Separación entre modelo, servicio y componente.

---

# 5. Pruebas

Se implementaron pruebas unitarias utilizando:

- xUnit
- FluentAssertions

Actualmente se encuentran cubiertas pruebas para:

- Validación del modelo Factura.
- Validación de creación de objetos.
- Verificación de propiedades requeridas.

Todas las pruebas ejecutan correctamente.

---

# 6. Seguridad

Las siguientes medidas fueron implementadas:

- Exclusión de archivos sensibles mediante `.gitignore`.
- Uso de User Secrets para credenciales.
- Separación de configuración por ambiente.
- No exposición de credenciales en el repositorio.

---

# 7. Decisiones Técnicas

Durante el desarrollo se tomaron las siguientes decisiones:

| Decisión | Motivo |
|----------|---------|
| ASP.NET Core 8 | Framework moderno, rápido y robusto |
| MongoDB Atlas | Facilidad de despliegue y administración |
| Angular | Framework estructurado y escalable |
| Repository Pattern | Separación de responsabilidades |
| Dependency Injection | Bajo acoplamiento |
| Swagger | Facilitar pruebas y documentación |
| xUnit | Framework estándar para testing |

---

# 8. Pasos de Despliegue

## Backend

### Requisitos

- .NET SDK 8
- MongoDB Atlas

### Instalación

```bash
git clone <repositorio>

cd backend/InvoiceReminder.API

dotnet restore

dotnet user-secrets init

dotnet user-secrets set "MongoDb:ConnectionString" "<cadena_mongodb>"

dotnet run
```

La API quedará disponible en:

```
http://localhost:5254
```

Swagger:

```
http://localhost:5254/swagger
```

---

## Frontend

### Requisitos

- Node.js
- Angular CLI

### Instalación

```bash
cd frontend/invoice-reminder-ui

npm install

ng serve
```

La aplicación quedará disponible en:

```
http://localhost:4200
```

---

# 9. Mejoras Futuras

Si el proyecto continuara evolucionando, los siguientes pasos serían:

- Implementar autenticación y autorización.
- Incorporar validaciones con FluentValidation.
- Agregar pruebas de integración.
- Implementar Docker y Docker Compose.
- Configurar CI/CD mediante GitHub Actions.
- Incorporar logging estructurado con Serilog.
- Agregar manejo global de excepciones.
- Implementar paginación y filtros.
- Desplegar infraestructura cloud.

---

# 10. Conclusiones

La solución fue desarrollada priorizando:

- Separación de responsabilidades.
- Mantenibilidad.
- Escalabilidad.
- Buenas prácticas de desarrollo.
- Seguridad en el manejo de credenciales.
- Facilidad de pruebas y extensión futura.

La arquitectura implementada permite evolucionar la aplicación hacia un entorno productivo con cambios mínimos en la estructura actual.