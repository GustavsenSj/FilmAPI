using System.Reflection;
using AutoMapper;
using FilmAPI.Data;
using FilmAPI.MappingProfiles;
using FilmAPI.Services.Character;
using FilmAPI.Services.Movie;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Film API",
        Description = "An ASP.NET Core Web API for managing movies with characters and franchises.",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<FilmDbContext>(options 
                => options.UseSqlServer(builder.Configuration.GetConnectionString("Filmdb"))); 

builder.Services.AddScoped<ICharacterService, CharacterService>();            
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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