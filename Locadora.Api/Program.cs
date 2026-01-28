using Locadora.Api;
using Locadora.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocadoraInfrastructure(builder.Configuration);
builder.Services.AddLocadoraApplication();
builder.Services.AddCors(opt =>
{
	opt.AddDefaultPolicy(p => p
		.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod());
});

var app = builder.Build();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

app.UseLocadoraEventSubscriptions();

if (app.Environment.IsDevelopment())
{
	await app.SeedDevDataAsync();
}

app.MapLocadoraEndpoints();

app.Run();
