using AutoMapper;
using FilmAPI.Data;
using FilmAPI.MappingProfiles;
using FilmAPI.Services.Character;
using FilmAPI.Services.Movie;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Reg. automapping,
// src: https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core
builder.Services.AddAutoMapper(typeof(CharacterProfile));

builder.Services.AddDbContext<FilmDbContext>(options 
                => options.UseSqlServer(builder.Configuration.GetConnectionString("Filmdb"))); 

builder.Services.AddScoped<ICharacterService, CharacterService>();            
builder.Services.AddScoped<IMovieService, MovieService>();
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
