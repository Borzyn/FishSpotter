using Microsoft.EntityFrameworkCore;
//using System.Text.Json.Serialization;

using Microsoft.Extensions.DependencyInjection;
using FishSpotter.Server.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FishSpotterServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FishSpotterServerContext") ?? throw new InvalidOperationException("Connection string 'FishSpotterServerContext' not found.")));
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
