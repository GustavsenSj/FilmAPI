namespace FilmAPI.Data.Models
{
    // Rep. m2m relation between movie&character
    public class MovieCharacter
    {
        /*-------------------------------Movie stuff---------------------------------*/
        // FK to rep Movie related to this
        public int MovieId { get; set; }
        public Movie Movie { get; set; } // nav prop to related movie
        /*---------------------------------------------------------------------------*/


        /*----------------------------------Chr stuff--------------------------------------*/

        // FK to rep Character to this
        public int CharacterId { get; set; }
        public Character Character { get; set; } // nav prop for realted char
        /*---------------------------------------------------------------------------------*/

    }
}
