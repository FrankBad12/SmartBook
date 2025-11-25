using SmartBook.Application.Services;
using SmartBook.Persistence.DbContexts;
using SmartBook.Persistence.Repositories;
using SmartBook.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SmartBookDbContext>(op => op.UseMySQL(connectionString));

// Registrar repositorios y servicios
builder.Services.AddScoped<IUsuarioRepository, UsuarioEfcRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddScoped<ILibroRepository, LibroEfcRepository>();
builder.Services.AddScoped<LibroService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioEfcRepository>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();