using Autofac.Core;
using FluentValidation;
using Management.Application.Features.Clients.Commands.CreateClient;
using Management.Domain.Clients;
using Management.Domain.Repositories;
using Management.Infrastructure.Contexts;
using Management.Infrastructure.Domain.Clients;
using Management.Infrastructure.Repositories;
using Management.Infrastruncture.Domain.Clients;
using Management.Models;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DB Config
builder.Services.Configure<ClientConfiguration>(
    options =>
    {
        options.ConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
        options.Database = builder.Configuration.GetSection("MongoDB:Database").Value;
    }
);

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<IClientContext, ClientContext>();
builder.Services.AddScoped<IManagementUnitOfWork, ManagementUnitOfWork>();
builder.Services.AddScoped<IClientReadOnlyRepository, ClientReadOnlyRepository>();
builder.Services.AddScoped<IClientCommandRepository, ClientCommandRepository>();
builder.Services.AddControllers();
// add mediators querries/commands
builder.Services.AddMediatR(typeof(CreateClientCommand));

//Auto Mapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Bills Management API",
        Description = "Bills Management API"
    });
    options.ExampleFilters();
    options.EnableAnnotations();
    options.IgnoreObsoleteActions();
    options.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();


builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


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