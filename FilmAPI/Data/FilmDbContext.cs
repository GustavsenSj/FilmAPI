using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace FilmAPI.Data;


public class FilmDbContext :DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("conection string here");
    }
}