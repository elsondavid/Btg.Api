// Versão CORRIGIDA:
using Btg.Api;
using Btg.Core.Repository;
using Btg.Persistence;
using Btg.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // "VerbApplication" -> "WebApplication"

builder.Services.AddControllers();

// Configuração CORRETA do DbContext:
builder.Services.AddDbContext<DbContextBase>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Corrigido "UssSqlServer"

builder.Services.AddScoped<IConfigurationManager>(_ => builder.Configuration);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.AddServiceRegistry();

// Configuração do Swagger (opcional):
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Substitui MapOpenApi
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();