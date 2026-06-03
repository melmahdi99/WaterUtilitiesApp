using Application;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.WaterTreatmentPlant;
using Persistence.WaterTreatmentPlant;
using Microsoft.AspNetCore.Identity;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IBillingService, BillingService_Impl>();
builder.Services.AddScoped<IBillingRepo, BillingRepo_Impl>();
builder.Services.AddScoped<IBuildingRepo, BuildingRepo>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
// customer
builder.Services.AddScoped<IWaterMeterRepo, WaterMeterRepo>();
builder.Services.AddScoped<IWaterMeterService, WaterMeterService>();
builder.Services.AddScoped<IWaterTreatmentPlantService, WaterTreatmentPlantService>();
builder.Services.AddScoped<IWaterTreatmentPlantRepo, WaterTreatmentPlantRepo>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddIdentityApiEndpoints<User>(opt =>
{
    opt.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

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
        .AllowCredentials()
        .AllowAnyMethod();
    });
});

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseCors("AllowFrontend");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("api").MapIdentityApi<User>();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await DbInit.SeedData(context);
    await DbInitializerWaterTreatmentPlant.SeedData(context, userManager, roleManager);
}
catch(Exception e)
{
    logger.LogError(e, "An error occurred during migration");
}

app.Run();
