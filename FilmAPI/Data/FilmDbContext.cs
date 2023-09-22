using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Data;

public class FilmDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Franchise> Franchises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "data source=N-NO-01-03-2688; initial catalog=FilmDb;Integrated Security = true; Trust Server Certificate = true;");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1, Title = "Star Wars", Genre = "SciFi", ReleaseYear = 1997, Director = "George Lucas",
                Picture = null, Trailer = null
            },
            new Movie
            {
                Id = 2, Title = "The Empire Strikes Back", Genre = "SciFi", ReleaseYear = 1980,
                Director = "George Lucas", Picture = null, Trailer = null
            },
            new Movie
            {
                Id = 3, Title = "Return of the Jedi", Genre = "SciFi", ReleaseYear = 1983, Director = "George Lucas",
                Picture = null, Trailer = null
            },
            new Movie
            {
                Id = 4, Title = "The Phantom Menace", Genre = "SciFi", ReleaseYear = 1999, Director = "George Lucas",
                Picture = null, Trailer = null
            },
            new Movie
            {
                Id = 5, Title = "Attack of the Clones", Genre = "SciFi", ReleaseYear = 2002, Director = "George Lucas",
                Picture = null, Trailer = null
            },
            new Movie
            {
                Id = 6, Title = "Revenge of the Sith", Genre = "SciFi", ReleaseYear = 2005, Director = "George Lucas",
                Picture = null, Trailer = null
            }
        );
    }
}