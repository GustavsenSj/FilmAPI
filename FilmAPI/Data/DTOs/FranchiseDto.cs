using FilmAPI.Data.DTOs.Movies;

namespace FilmAPI.Data.DTOs
{
    public class FranchiseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<MovieDto> Movies { get; set; }
    }
}
