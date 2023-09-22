namespace FilmAPI.Data.Models
{
    public class Franchise
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        /*------------------------iT's movies realtion stuff------------------------------*/
        // nav prop for franchise's related movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        /*--------------------------------------------------------------------------------*/

    }
}