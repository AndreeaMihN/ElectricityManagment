using FluentValidation;
using Management.Domain.Clients;
using Management.Domain.Repositories;
using Management.Infrastructure.Contexts;
using Management.Infrastructure.Domain.Clients;
using Management.Infrastructure.Repositories;
using Management.Infrastruncture.Domain.Clients;
using Management.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;

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
builder.Services.AddSingleton<IClientContext, ClientContext>();
//builder.Services.AddMediatR(typeof(Program));
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Authority = "https://localhost:5011";
    o.Audience = "managementapi"; // APi Resource Name
    o.RequireHttpsMetadata = false;
});

builder.Services.AddSingleton<IClientContext, ClientContext>();
builder.Services.AddScoped<IManagementUnitOfWork, ManagementUnitOfWork>();
builder.Services.AddScoped<IClientReadOnlyRepository, ClientReadOnlyRepository>();
builder.Services.AddScoped<IClientCommandRepository, ClientCommandRepository>();
builder.Services.AddControllers();
//Auto Mapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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