using System.ComponentModel.DataAnnotations;

namespace FilmAPI.Data.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 


        /*------------------------iT's movies realtion stuff------------------------------*/
        // nav prop for franchise's related movies
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        /*--------------------------------------------------------------------------------*/

    }
}