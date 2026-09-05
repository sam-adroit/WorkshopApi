using Microsoft.EntityFrameworkCore;
using WorkshopApi.Data;
using WorkshopApi.Interfaces;
using WorkshopApi.Repositories;
using WorkshopApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var connStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connStr));
builder.Services.AddOpenApi();

builder.Services.AddScoped<IWorkshopRepository, WorkshopRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
