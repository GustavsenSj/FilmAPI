using FilmAPI.Data.DTOs.Movies;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace FilmAPI.Data.Dtos.Characters
{
    /// <summary>
    /// CharacterDto is a DTO for Character objects.
    /// </summary>
    public class CharacterDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? Picture { get; set; }
        public List<MovieDto> Movies { get; set; } = null!;
    }
}
