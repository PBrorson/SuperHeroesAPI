using Microsoft.EntityFrameworkCore;
using SuperHeroesAPI.Data;
using SuperHeroesAPI.Interfaces;
using SuperHeroesAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("SuperHeroDomain",
        policy => policy.WithOrigins("http://localhost:3001")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        );
});
builder.Services.AddDbContext<HeroDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReactApp"));
});
builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("SuperHeroDomain");

app.UseAuthorization();

app.MapControllers();

app.Run();
