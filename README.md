# 📘 SLSuperContact

Proyecto API RESTful para gestión de contactos usando .NET 8 + Minimal API, con Entity Framework Core, SQL Server y arquitectura por capas.

---

## 📦 Estructura del Proyecto
SLSuperContact/
├── SC.API/ # Proyecto API (Minimal API)
├── Data/ # Proyecto con ApplicationDbContext y Migrations
├── SC.Entities/ # Entidades (Ej: Contacto)
├── SC.Repositories/ # Lógica de acceso a datos (Interfaces + Implementación)
├── SC.Services/ # Lógica de negocio (Interfaces + Implementación)
├── SLSuperContact.sln # Solución


---

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local o remoto)
- Visual Studio 2022+ o VS Code
- CLI de EF Core: `dotnet tool install --global dotnet-ef`

---

## 🔧 Configuración

### 1. `appsettings.json` en `SC.API`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MiContactos;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Modifica el Server según tu entorno:

    localhost\\SQLEXPRESS → si usas SQL Express

    Server=mi-servidor-sql;User Id=usuario;Password=clave; → autenticación SQL

2. Configurar DbContext en Program.cs de SC.API

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

3. Paquetes NuGet requeridos en Data.csproj

<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0">
    <PrivateAssets>all</PrivateAssets>
  </PackageReference>
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0">
    <PrivateAssets>all</PrivateAssets>
  </PackageReference>
</ItemGroup>

🏗️ Migraciones y Base de Datos
🔹 Crear migración inicial

dotnet ef migrations add InitialCreate --project Data/Data.csproj --startup-project SC.API/SC.API.csproj

🔹 Aplicar migración (crear DB)

dotnet ef database update --project Data/Data.csproj --startup-project SC.API/SC.API.csproj

    ⚠️ Si ves errores de compilación, primero ejecuta:

    dotnet build SLSuperContact.sln

🧪 Probar los Endpoints

Con herramientas como Postman, Insomnia o CURL:
🔹 Listar todos los contactos

GET /contactos

🔹 Obtener un contacto por ID

GET /contactos/1

🔹 Crear un nuevo contacto

POST /contactos
Content-Type: application/json

{
  "nombre": "Juan Pérez",
  "email": "juan@example.com",
  "telefono": "809-555-1234"
}

🔹 Actualizar contacto

PUT /contactos/1
Content-Type: application/json

{
  "id": 1,
  "nombre": "Juan P. Editado",
  "email": "juan.p@example.com",
  "telefono": "809-555-0000"
}

🔹 Eliminar contacto

DELETE /contactos/1

🧠 Buenas prácticas aplicadas

    ✔️ Separación por capas (Entities, Repositories, Services, API)

    ✔️ Inyección de dependencias

    ✔️ EF Core con migraciones y configuración limpia

    ✔️ Minimal API para endpoints simples y rápidos

    ✔️ Uso de DbContext con SqlServer seguro y preparado para producción

❓ Problemas comunes

    ❌ No project was found: asegúrate de estar en la raíz del .sln o usa --project.

    ❌ ModelSnapshot not found: falta instalar EFCore.Design.

    ❌ Build failed: ejecuta dotnet build para ver el error exacto.

    ❌ DB no se crea: verifica la cadena de conexión y si tienes permisos en SQL Server.

👨‍💻 Autor

Desarrollado por Juan Montilla
📝 Licencia

MIT
