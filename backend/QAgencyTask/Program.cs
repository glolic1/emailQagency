using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QAgencyTask;
using QAgencyTask.Context;
using QAgencyTask.Models;
using QAgencyTask.Services;
using QAgencyTask.Services.Interfaces;
using System.Configuration;

var CorsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                      builder =>
                      {
                          builder
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithOrigins("http://localhost:65445");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QagencyTaskContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//var mapperConfig = new MapperConfiguration(config =>
//{
//    config.AddProfile(new MappingProfile());
//}).CreateMapper();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddSingleton(mapperConfig);

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
