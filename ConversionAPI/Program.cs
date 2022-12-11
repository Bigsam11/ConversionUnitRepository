using AutoMapper;
using ConversionAPI.Infrastructure.Services;
using ConversionAPI.Infrastructure.Services.Impl;
using ConversionService.Core.Helpers;
using ConversionService.Core.Repository;
using ConversionService.Core.Repository.Impl;
using ConversionService.Infrastructure.Services;
using ConversionService.Infrastructure.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IConversionUnitsRepository,ConversionUnitsRepository>();
builder.Services.AddScoped<IConversionUnitService,ConversionUnitService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IConversionActionRepository,ConversionActionRepository>();
builder.Services.AddScoped<IConversionActionService,ConversionActionService>();
builder.Services.AddScoped<IAuditRepository,AuditRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<DataContext>();
//builder.Services.AddControllersWithViews()
//    .AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);
builder.Services.AddMvc()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
///* Database Context Dependency Injection */
/* ===================================== */


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var dbHost = Environment.GetEnvironmentVariable("POSTGRES_HOST");
//var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
//var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
//var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
//var ConnectionString = $"Host={dbHost}; Database={dbName}; Username={dbUser};Port=5432 Password={dbPassword}";
//builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

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
