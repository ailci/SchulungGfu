using Application;
using Application.Contracts.Services;
using Persistence;
using Scalar.AspNetCore;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //WebaPI
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//DB
builder.Services
    .AddPersistenceServices(builder.Configuration)
    .AddApplicationServices();

builder.Services.AddScoped<IQotdService, QotdDbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
