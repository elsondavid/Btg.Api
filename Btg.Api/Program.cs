// Versão CORRIGIDA:
using Btg.Api;
using Btg.Core.Repository;
using Btg.Persistence;
using Btg.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // "VerbApplication" -> "WebApplication"

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContextBase>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<IConfigurationManager>(_ => builder.Configuration);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.AddServiceRegistry();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();