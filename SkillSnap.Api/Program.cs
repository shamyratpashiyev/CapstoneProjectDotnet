using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SkillSnap.Api.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddDbContext<SkillSnapContext>(options =>
    options.UseSqlite("Data Source=Data/skillsnap.db"));

// Add OpenAPI/Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy.WithOrigins("http://localhost:5106")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowClient");


// Enable middleware for Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();            // Generates Swagger JSON
    app.UseSwaggerUI();          // Enables the UI at /swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();