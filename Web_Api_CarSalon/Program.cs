using Core.Interfaces;
using Core.MapperProfiles;
using Core.Services;
using Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Web_Api_CarSalon.Middlewares;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Web_Api_CarSalon.Extensions;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(connectionString);
builder.Services.AddIdentity();

builder.Services.AddFluentValidators();

builder.Services.AddMapper();

builder.Services.AddServices();

builder.Services.AddJwtOptions(builder.Configuration);

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddSwaggerToken();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionHandler();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
