namespace FilmAPI.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string? Picture { get; set;} // Can be nullable


        /*--------------------------Movie relation stuff------------------------------*/
        // Associated movies for character nav prop
        public ICollection<MovieCharacter> MoviesCharacters { get; set; } = new List<MovieCharacter>();
        /*----------------------------------------------------------------------------*/

    }
}