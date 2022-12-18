using ElectricityManagment.Models;
using ElectricityManagment.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<ManagementDatabaseSettings>(builder.Configuration.GetSection(nameof(ManagementDatabaseSettings)));
builder.Services.AddSingleton<IManagmentDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ManagementDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ManagementDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IClientService, ClientService>();
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
