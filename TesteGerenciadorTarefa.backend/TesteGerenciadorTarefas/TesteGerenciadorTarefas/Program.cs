using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;
using System.Runtime.CompilerServices;
using TesteGerenciadorTarefas.Domain.Interfaces.Mensageria;
using TesteGerenciadorTarefas.Domain.Interfaces.Repository;
using TesteGerenciadorTarefas.Domain.Interfaces.Services;
using TesteGerenciadorTarefas.Domain.Services.Services;
using TesteGerenciadorTarefas.Infra.Context;
using TesteGerenciadorTarefas.Infra.Mensageria;
using TesteGerenciadorTarefas.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Adicionar suporte ao log com SERILOG
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/TarefasLog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BdContexto>(
    options => options.UseSqlServer(
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbTarefa;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddScoped<ITarefaDomainService, TarefaService>();
builder.Services.AddScoped<ITarefaDomainRepository, TarefaRepository>();
builder.Services.AddScoped<IMensageriaService, MensageriaService>();

var assemblies = Assembly.Load("TesteGerenciadorTarefas.Application");

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(assemblies));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
