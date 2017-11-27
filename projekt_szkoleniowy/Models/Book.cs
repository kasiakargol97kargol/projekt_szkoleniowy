using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt_szkoleniowy.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        [MaxLength(300, ErrorMessage = "Za długi tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Proszę podać datę wydania")]
        public System.DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Proszę podać numer ISBN")]
        [Range(9780000000000, 9800000000000,
            ErrorMessage = "Numer ISBN powinien składać się z 13 cyfr i zaczynać się cyframi 978")]
        public long ISBN { get; set; }
        [Required(ErrorMessage = "Proszę podać autora")]
        public Author Author { get; set; }
    }
}