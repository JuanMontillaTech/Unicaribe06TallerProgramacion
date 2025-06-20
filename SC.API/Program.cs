using Data;
using Microsoft.EntityFrameworkCore;
using SC.Entities;
using SC.Repositories;
using SC.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

        
 
builder.Services.AddScoped<IContactoService, ContactoService>();
builder.Services.AddScoped<IContactoRepository, ContactoRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/contactos", async (IContactoService servicio) =>
    Results.Ok(await servicio.ObtenerTodosAsync()));

app.MapGet("/contactos/{id:int}", async (int id, IContactoService servicio) =>
{
    var contacto = await servicio.ObtenerPorIdAsync(id);
    return contacto is null ? Results.NotFound() : Results.Ok(contacto);
});

app.MapPost("/contactos", async (Contacto contacto, IContactoService servicio) =>
{
    await servicio.CrearAsync(contacto);
    return Results.Created($"/contactos/{contacto.Id}", contacto);
});

app.MapPut("/contactos/{id:int}", async (int id, Contacto input, IContactoService servicio) =>
{
    var existente = await servicio.ObtenerPorIdAsync(id);
    if (existente is null) return Results.NotFound();

    existente.Nombre = input.Nombre;
    existente.Email = input.Email;
    existente.Telefono = input.Telefono;

    await servicio.ActualizarAsync(existente);
    return Results.NoContent();
});

app.MapDelete("/contactos/{id:int}", async (int id, IContactoService servicio) =>
{
    await servicio.EliminarAsync(id);
    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
