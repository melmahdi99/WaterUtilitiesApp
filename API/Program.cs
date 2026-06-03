using Application;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.WaterTreatmentPlant;
using Persistence.WaterTreatmentPlant;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IWaterTreatmentPlantService, WaterTreatmentPlantService>();
builder.Services.AddScoped<IWaterTreatmentPlantRepo, WaterTreatmentPlantRepo>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Information);

builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://127.0.0.1:3000", "https://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await DbInitializerWaterTreatmentPlant.SeedData(context);
}
catch(Exception e)
{
    logger.LogError(e, "An error occurred during migration");
}

app.Run();
