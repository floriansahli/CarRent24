using CarRent24.Common;
using CarRent24.Feature.Cars.Domain;
using CarRent24.Feature.Cars.Infrastructure;
using CarRent24.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CarRentDbContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRent;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CarRentDbContext>());
builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();
builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<CarRentDbContext>();

    // deletes and creates the database on startup
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}



app.UseHttpsRedirection();

app.Run();

