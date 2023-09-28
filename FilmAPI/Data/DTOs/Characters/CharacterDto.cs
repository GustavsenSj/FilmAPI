using FilmAPI.Data.DTOs.Movies;

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
        public List<MovieInCharacterDto> Movies { get; set; } = null!;
    }
}
