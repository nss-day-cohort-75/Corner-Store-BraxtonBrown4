using CornerStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using AutoMapper.QueryableExtensions;
using CornerStore.Models.DTOS.Default;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core and provides dummy value for testing
builder.Services.AddNpgsql<CornerStoreDbContext>(builder.Configuration["CornerStoreDbConnectionString"] ?? "testing");

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region cashiers

app.MapGet("/cashiers", (CornerStoreDbContext db, IMapper mapper) =>
{
    return db.Cashiers.ProjectTo<DefaultCashierDTO>(mapper.ConfigurationProvider).ToList();
});

app.MapGet("/cashiers/{id}", (int id, CornerStoreDbContext db, IMapper mapper, string? expand) =>
{
    if (expand == null)
    {
        return db.Cashiers.ProjectTo<DefaultCashierDTO>(mapper.ConfigurationProvider).SingleOrDefault(c => c.Id == id);
    }
});

#endregion

app.Run();

//don't move or change this!
public partial class Program { }