using Locadora.Api;
using Locadora.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocadoraInfrastructure(builder.Configuration);
builder.Services.AddLocadoraApplication(); // opcional; aqui fica só os use cases se quiser

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseLocadoraEventSubscriptions();

if (app.Environment.IsDevelopment())
{
    await app.SeedDevDataAsync();
}

app.MapLocadoraEndpoints();

app.Run();
