using Application;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IBuildingRepo, BuildingRepo>();
builder.Services.AddScoped<IBuildingService, BuildingService>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddResponseCaching();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
