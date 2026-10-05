using Serilog;
using Microsoft.EntityFrameworkCore;
using MaintenanceBackend;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure Serilog to replace the default .NET logger
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

// 2. Configure Entity Framework to use Postgres
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.MapGet("/api/maintenance/ping", () => "Hello from the hidden Maintenance Backend!");

app.Run();