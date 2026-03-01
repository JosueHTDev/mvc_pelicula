using DbModel.cineDb;
using Microsoft.EntityFrameworkCore;
using Mvc.Bussnies.GeneroPeliculaB;
using Mvc.Bussnies.Pelicula;
using Mvc.Repository.GeneroPeliculaRepo.Contratos;
using Mvc.Repository.GeneroPeliculaRepo.Implementacion;
using Mvc.Repository.PeliculaRepo.Contratos;
using Mvc.Repository.PeliculaRepo.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar la conexión a la base de datos
builder.Services.AddDbContext<_cineContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("cineDb");
    // Evita AutoDetect (que abre una conexión en startup). Usa la versión conocida del servidor.
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.45-mysql"));
});

// Inyección de dependencias - Repositories
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();
builder.Services.AddScoped<IPeliculaBussnies, PeliculaBussnies>();

builder.Services.AddScoped<IGeneroPeliculaRepository, GeneroPeliculaRepository>();
builder.Services.AddScoped<IGeneroPeliculaBussnies, GeneroPeliculaBussnies>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
