using KolosPowtórka.Models;
using KolosPowtórka.Repositories.Implementations;
using KolosPowtórka.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IClientTripRepository, ClientTripRepository>();

builder.Services.AddDbContext<MasterContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
    opt.LogTo(Console.WriteLine);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
