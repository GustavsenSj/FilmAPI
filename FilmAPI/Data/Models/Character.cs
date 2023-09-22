using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmAPI.Data.Models
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(60)]
        public string FullName { get; set; } = null!;
        [StringLength(60)]
        public string? Alias { get; set; }
        [StringLength(15)]
        public string Gender { get; set; } = null!;
        public string? Picture { get; set; } // Can be nullable


        /*--------------------------Movie relation stuff------------------------------*/
        // Associated movies for character nav prop
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        /*----------------------------------------------------------------------------*/
    }
}