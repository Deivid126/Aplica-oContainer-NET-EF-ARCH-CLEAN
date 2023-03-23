using AplicaçãoContainer.Application.Services;
using AplicaçãoContainer.Core.Interfaces;
using AplicaçãoContainer.Infratructure.Data;
using AplicaçãoContainer.Infratructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContainerDb>(options => 
options.UseSqlServer("Server=DESKTOP-B8QLIC0\\SQLEXPRESS;Database=TesteDb;Integrated Security = True;TrustServerCertificate=True"));
builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
builder.Services.AddScoped<IMovimetacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IContainerService, ContainerService>();
builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddControllers();

var app = builder.Build();

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
