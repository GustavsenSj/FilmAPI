namespace FilmAPI.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }   
        public string Gender { get; set; }
        public string Picture { get; set; }
        
        public Movie Movie { get; set; } // Nav prop to realted movie.

        public int MovieId { get; set; } // FK for related movies Id
    }
}